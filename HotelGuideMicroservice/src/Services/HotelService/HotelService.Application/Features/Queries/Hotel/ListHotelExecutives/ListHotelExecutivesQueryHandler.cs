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

namespace HotelService.Application.Features.Queries.Hotel.ListHotelExecutives
{
    public class ListHotelExecutivesQueryHandler : IRequestHandler<ListHotelExecutivesQuery, HotelExecutiveDTO>
    {
        private readonly IHotelRepository _hotelRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<ListHotelExecutivesQueryHandler> _logger;

        public ListHotelExecutivesQueryHandler(IHotelRepository hotelRepository, IMapper mapper, ILogger<ListHotelExecutivesQueryHandler> logger)
        {
            _hotelRepository = hotelRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<HotelExecutiveDTO> Handle(ListHotelExecutivesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var hotelExecutives = await _hotelRepository.GetByIdAsync(request.HotelId);

                if (hotelExecutives == null)
                {
                    _logger.LogWarning($"No executives found for the hotel with ID - {request.HotelId}.");
                    return null;
                }

                var executiveDTOs = _mapper.Map<HotelExecutiveDTO>(hotelExecutives);
                return executiveDTOs;
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred while getting executives for the hotel with ID - {request.HotelId}. Error: {ex.Message}");
                throw;
            }
        }
    }
}
