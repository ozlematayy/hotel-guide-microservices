using AutoMapper;
using HotelService.Domain.DTOs;
using HotelService.Domain.Repository;
using HotelService.Domain.UnitOfWorks;
using MediatR;
using Microsoft.Extensions.Logging;
using HotelService.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelService.Application.Features.Commands.Hotel.CreateHotel
{
    public class CreateHotelCommandHandler : IRequestHandler<CreateHotelCommand,HotelDTO>
    {
        private readonly IHotelRepository _hotelRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<CreateHotelCommandHandler> _logger;
        private readonly IMapper _mapper;

        public CreateHotelCommandHandler(IHotelRepository hotelRepository, IUnitOfWork unitOfWork, ILogger<CreateHotelCommandHandler> logger,IMapper mapper)
        {
            _hotelRepository = hotelRepository;
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<HotelDTO> Handle(CreateHotelCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var newHotel = await CreateHotelAsync(request.CreateHotelDto);
                var hotelEntity = _mapper.Map<HotelModel>(newHotel);
                await _hotelRepository.AddAsync(hotelEntity);
                await _unitOfWork.CommitAsync();
                return newHotel;

            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "An error occurred while adding a hotel.");
                throw;
            }
        }

        private async Task<HotelDTO> CreateHotelAsync(CreateHotelDTO createHotelDto)
        {
           
            var result = new HotelDTO
            {
                AuthorizedPersonFirstName = createHotelDto.AuthorizedPersonFirstName,
                AuthorizedPersonLastName = createHotelDto.AuthorizedPersonLastName,
                CompanyTitle = createHotelDto.CompanyTitle
            };

            return result;
        }
    }
}
