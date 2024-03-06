using AutoMapper;
using HotelService.Domain.DTOs;
using HotelService.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelService.Application.Mapper
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<HotelModel, HotelDTO>().ReverseMap();
            CreateMap<HotelDTO, HotelModel>();
            CreateMap<ContactDTO, ContactModel>();
            CreateMap<ContactModel, ContactDTO>().ReverseMap();
            CreateMap<HotelDetailsDTO,HotelModel>();
            CreateMap<HotelModel, HotelDetailsDTO>().ReverseMap();
            CreateMap<HotelModel, HotelExecutiveDTO>().ReverseMap();
            CreateMap<HotelExecutiveDTO, HotelModel>();


        }
    }
}
