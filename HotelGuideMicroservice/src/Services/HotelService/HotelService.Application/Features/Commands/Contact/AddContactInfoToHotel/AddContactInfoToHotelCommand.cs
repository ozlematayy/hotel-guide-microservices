using HotelService.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelService.Application.Features.Commands.Contact.AddContactInfoToHotel
{
    public class AddContactInfoToHotelCommand : IRequest<bool>
    {
        public int HotelUUID { get; set; }
        public InfoType Type { get; set; }
        public string Content { get; set; }

        public AddContactInfoToHotelCommand(int hotelUUID, InfoType type, string content)
        {
            HotelUUID = hotelUUID;
            Type = type;
            Content = content;
        }
    }
}
