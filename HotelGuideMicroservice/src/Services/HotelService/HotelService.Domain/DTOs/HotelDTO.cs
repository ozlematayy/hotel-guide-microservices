using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelService.Domain.DTOs
{
    public class HotelDTO:BaseDTO
    {
        public string AuthorizedPersonFirstName { get; set; }
        public string AuthorizedPersonLastName { get; set; }
        public string CompanyTitle { get; set; }
    }
}
