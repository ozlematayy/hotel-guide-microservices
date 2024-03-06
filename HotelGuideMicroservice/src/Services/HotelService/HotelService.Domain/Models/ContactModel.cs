using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelService.Domain.Models
{
    public class ContactModel:BaseEntity
    {
        public int HotelUUID { get; set; }
        public HotelModel Hotel { get; set; }
        public InfoType Type { get; set; }
        public string Content { get; set; }
    }

    public enum InfoType
    {
        Phone=1,
        EMail=2,
        Location=3
    }

}
