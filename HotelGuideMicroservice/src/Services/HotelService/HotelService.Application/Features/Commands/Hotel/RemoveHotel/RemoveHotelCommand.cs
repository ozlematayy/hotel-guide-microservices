using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelService.Application.Features.Commands.Hotel.RemoveHotel
{
    public class RemoveHotelCommand:IRequest<bool>
    {
        public int HotelId { get; set; }

        public RemoveHotelCommand(int hotelId)
        {
            HotelId = hotelId;
        }
    }
}
