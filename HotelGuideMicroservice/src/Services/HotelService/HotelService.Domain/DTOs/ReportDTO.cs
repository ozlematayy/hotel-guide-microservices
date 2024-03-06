using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelService.Domain.DTOs
{
    public class ReportDTO:BaseDTO
    {
        public DateTime RequestedDate { get; set; }
        public string Location { get; set; }
        public int HotelCount { get; set; }
        public int NumberCount { get; set; }
        public string Status { get; set; }
    }
}
