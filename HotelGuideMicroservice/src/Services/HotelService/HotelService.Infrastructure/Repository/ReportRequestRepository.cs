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
    public class ReportRequestRepository : GenericRepository<ReportRequest>, IReportRequestRepository
    {
        public ReportRequestRepository(AppDbContext context) : base(context)
        {
        }
    }
}
