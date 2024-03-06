using Consul;
using HotelService.Api.Extensions;
using HotelService.Application.Features.Commands.Hotel.CreateHotel;
using HotelService.Application.Mapper;
using HotelService.Domain.Repository;
using HotelService.Domain.Services;
using HotelService.Domain.UnitOfWorks;
using HotelService.Infrastructure.Context;
using HotelService.Infrastructure.Repository;
using HotelService.Infrastructure.UnitOfWorks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureConsul(configuration);
var appLifetime = builder.Services.BuildServiceProvider().GetService<IHostApplicationLifetime>();

builder.Services.AddAutoMapper(typeof(MapProfile));
builder.Services.AddHttpContextAccessor();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

builder.Services.AddDbContext<AppDbContext>(
        x => x.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"),
        option =>
        {
            option.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext)).GetName().Name);
        }));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
app.RegisterWithConsul(appLifetime);

app.WaitForShutdown();
