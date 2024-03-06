using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelService.Domain.Models
{
    public class ReportDetail:BaseEntity
    {
        public int ReportRequestId { get; set; }
        public ReportRequest ReportRequest { get; set; }
        public string Location { get; set; }
        public int HotelCount { get; set; }
        public int NumberCount { get; set; }
    }
}
