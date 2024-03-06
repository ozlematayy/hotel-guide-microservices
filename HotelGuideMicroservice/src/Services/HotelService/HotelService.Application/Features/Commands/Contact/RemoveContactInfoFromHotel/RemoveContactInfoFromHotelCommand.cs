using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelService.Application.Features.Commands.Contact.RemoveContactInfoFromHotel
{
    public class RemoveContactInfoFromHotelCommand:IRequest<bool>
    {
        public int ContactId { get; set; }

        public RemoveContactInfoFromHotelCommand(int contactId)
        {
            ContactId = contactId;
        }
    }
}
