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
    public class ReportDetailConfigurations : IEntityTypeConfiguration<ReportDetail>
    {
        public void Configure(EntityTypeBuilder<ReportDetail> builder)
        {
            builder.HasKey(x => x.ReportRequestId);
            builder.Property(x => x.ReportRequestId).UseIdentityColumn();

            builder.Property(x => x.Location).IsRequired();

        }
    }
}
