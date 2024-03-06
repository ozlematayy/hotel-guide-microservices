using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelService.Application.IntegrationEvents.Events
{
    public class ContactInformationAddedEvent : INotification
    {
        public int HotelId { get; }
        public int ContactInformationId { get; }

        public ContactInformationAddedEvent(int hotelId, int contactInformationId)
        {
            HotelId = hotelId;
            ContactInformationId = contactInformationId;
        }
    }
}
