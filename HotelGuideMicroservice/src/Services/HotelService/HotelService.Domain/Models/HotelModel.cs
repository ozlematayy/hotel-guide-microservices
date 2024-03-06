using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelService.Domain.Models
{
    public class HotelModel:BaseEntity
    {
        public string CompanyTitle { get; set; }
        public string AuthorizedPersonFirstName { get; set; }
        public string AuthorizedPersonLastName { get; set; }
        public ICollection<ContactModel> Contacts { get; set; } = new List<ContactModel>();
    }
}
