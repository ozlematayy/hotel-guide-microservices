using HotelService.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelService.Infrastructure.Configurations
{
    public class HotelConfiguration : IEntityTypeConfiguration<HotelModel>
    {
        public void Configure(EntityTypeBuilder<HotelModel> builder)
        {
            builder.HasKey(x => x.UUID);
            builder.Property(x=>x.UUID).UseIdentityColumn();

            builder.Property(x => x.AuthorizedPersonFirstName).HasMaxLength(100).IsRequired();
            builder.Property(x=>x.AuthorizedPersonLastName).HasMaxLength(100).IsRequired();
            builder.Property(x=>x.CompanyTitle).HasMaxLength(100).IsRequired();
            
        }
    }
}
