using EventBus.Base.Abstraction;
using EventBus.Base;
using EventBus.Factory;
using ReportService.Api.IntegrationEvents.EventHandlers;
using ReportService.Api.IntegrationEvents.Events;
using Consul;
using ReportService.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureConsul(configuration);
var appLifetime = builder.Services.BuildServiceProvider().GetService<IHostApplicationLifetime>();

builder.Services.AddLogging(configure =>
{
    configure.AddConsole();
    configure.AddDebug();
});
builder.Services.AddTransient<ReportRequestCreatedIntegrationEventHandler>();
builder.Services.AddSingleton<IEventBus>(sp =>
{
    EventBusConfig config = new()
    {
        ConnectionRetryCount = 5,
        EventNameSuffix = "IntegrationEvent",
        SubscriberClientAppName = "ReportService",
        EventBusType = EventBusType.RabbitMQ
    };
    return EventBusFactory.Create(config, sp);
});

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

IEventBus eventBus = app.Services.GetRequiredService<IEventBus>();
eventBus.Subscribe<ReportRequestCreatedIntegrationEvent, ReportRequestCreatedIntegrationEventHandler>();

app.Run();
app.RegisterWithConsul(appLifetime);

app.WaitForShutdown();