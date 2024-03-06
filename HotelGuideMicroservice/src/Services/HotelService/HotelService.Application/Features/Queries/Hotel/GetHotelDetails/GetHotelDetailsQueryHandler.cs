using AutoMapper;
using HotelService.Domain.DTOs;
using HotelService.Domain.Repository;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelService.Application.Features.Queries.Hotel.GetHotelDetails
{
    public class GetHotelDetailsQueryHandler : IRequestHandler<GetHotelDetailsQuery, HotelDetailsDTO>
    {
        private readonly IHotelRepository _hotelRepository;
        private readonly IContactRepository _contactRepository;
        private readonly ILogger<GetHotelDetailsQueryHandler> _logger;
        private readonly IMapper _mapper;

        public GetHotelDetailsQueryHandler(IHotelRepository hotelRepository, IContactRepository contactRepository, ILogger<GetHotelDetailsQueryHandler> logger, IMapper mapper)
        {
            _hotelRepository = hotelRepository;
            _contactRepository = contactRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<HotelDetailsDTO> Handle(GetHotelDetailsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var existingHotel = await _hotelRepository.GetByIdAsync(request.HotelId);
                if (existingHotel == null)
                {
                    _logger.LogWarning($"The hotel with ID - {request.HotelId} could not be found.");
                    return null;
                }

                var contactInfos = await _contactRepository.GetContactInformationByHotelIdAsync(request.HotelId);
                var hotelDetailsDTO = _mapper.Map<HotelDetailsDTO>(existingHotel);
                hotelDetailsDTO.Contacts = _mapper.Map<List<ContactDTO>>(contactInfos);
                return hotelDetailsDTO;


            }
            catch (Exception ex)
            {

                _logger.LogError($"An error occurred while handling GetHotelDetailsQuery for hotel ID - {request.HotelId}. Error: {ex.Message}");
                throw;
            }
        }
    }
}
