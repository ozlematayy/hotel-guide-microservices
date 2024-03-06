using HotelService.Domain.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelService.Application.Features.Queries.Hotel.GetHotelDetails
{
    public class GetHotelDetailsQuery:IRequest<HotelDetailsDTO>
    {
        public int HotelId { get; set; }

        public GetHotelDetailsQuery(int hotelId)
        {
            HotelId = hotelId;
        }
    }
}
