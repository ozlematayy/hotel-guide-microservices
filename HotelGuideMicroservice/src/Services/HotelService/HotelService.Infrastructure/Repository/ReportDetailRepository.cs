using HotelService.Domain.Models;
using HotelService.Domain.Repository;
using HotelService.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelService.Infrastructure.Repository
{
    public class ReportDetailRepository : GenericRepository<ReportDetail>, IReportDetailRepository
    {
        public ReportDetailRepository(AppDbContext context) : base(context)
        {
        }
    }
}
