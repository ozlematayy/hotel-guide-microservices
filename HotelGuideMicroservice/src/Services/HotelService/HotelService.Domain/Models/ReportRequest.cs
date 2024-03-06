using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelService.Domain.Models
{
    public class ReportRequest:BaseEntity
    {
        public StatusType Status { get; set; }
    }
    public enum StatusType
    {
        Preparing,
        Done
    }
}
