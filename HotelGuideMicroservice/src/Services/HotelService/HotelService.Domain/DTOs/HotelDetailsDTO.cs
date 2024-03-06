﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelService.Domain.DTOs
{
    public class HotelDetailsDTO:BaseDTO
    {
        public string CompanyTitle { get; set; }
        public string AuthorizedPersonFirstName { get; set; }
        public string AuthorizedPersonLastName { get; set; }
        public ICollection<ContactDTO> Contacts { get; set; } = new List<ContactDTO>();
    }
}
