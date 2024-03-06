using HotelService.Domain.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelService.Application.Features.Commands.Hotel.CreateHotel
{
    public class CreateHotelCommand:IRequest<HotelDTO>
    {
        public CreateHotelDTO CreateHotelDto { get; set; }

        public CreateHotelCommand(CreateHotelDTO createHotelDto)
        {
            CreateHotelDto = createHotelDto;
        }
    }
}
