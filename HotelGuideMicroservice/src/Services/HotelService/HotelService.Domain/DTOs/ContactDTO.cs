using HotelService.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelService.Domain.DTOs
{
    public class ContactDTO:BaseDTO
    {
        public int HotelUUID { get; set; }
        public InfoType Type { get; set; }
        public string Content { get; set; }
    }
}
