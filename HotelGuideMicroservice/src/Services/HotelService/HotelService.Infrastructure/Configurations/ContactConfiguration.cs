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
    public class ContactConfiguration : IEntityTypeConfiguration<ContactModel>
    {
        public void Configure(EntityTypeBuilder<ContactModel> builder)
        {
            builder.HasKey(x => x.UUID);
            builder.Property(x => x.UUID).UseIdentityColumn();

            builder.Property(x => x.Type).IsRequired();
            builder.Property(x => x.Content).HasMaxLength(250).IsRequired();
        }
    }
}
