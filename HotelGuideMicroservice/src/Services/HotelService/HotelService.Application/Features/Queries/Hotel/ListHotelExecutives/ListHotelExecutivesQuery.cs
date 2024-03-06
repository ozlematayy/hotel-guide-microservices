using HotelService.Domain.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelService.Application.Features.Queries.Hotel.ListHotelExecutives
{
    public class ListHotelExecutivesQuery:IRequest<HotelExecutiveDTO>
    {
        public int HotelId { get; set; }

        public ListHotelExecutivesQuery(int hotelId)
        {
            HotelId = hotelId;
        }
    }
}
