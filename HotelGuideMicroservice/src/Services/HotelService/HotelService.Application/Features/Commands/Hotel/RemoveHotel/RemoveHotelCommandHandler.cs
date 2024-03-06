using HotelService.Domain.Repository;
using HotelService.Domain.UnitOfWorks;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelService.Application.Features.Commands.Hotel.RemoveHotel
{
    public class RemoveHotelCommandHandler : IRequestHandler<RemoveHotelCommand, bool>
    {
        private readonly IHotelRepository _hotelRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<RemoveHotelCommandHandler> _logger;

        public RemoveHotelCommandHandler(IHotelRepository hotelRepository, IUnitOfWork unitOfWork, ILogger<RemoveHotelCommandHandler> logger)
        {
            _hotelRepository = hotelRepository;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<bool> Handle(RemoveHotelCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingHotel = await _hotelRepository.GetByIdAsync(request.HotelId);
                if (existingHotel == null)
                {
                    _logger.LogWarning($"The hotel with ID - {request.HotelId} could not be found.");
                    return false;
                }

                _hotelRepository.Remove(existingHotel);
                await _unitOfWork.CommitAsync();
                return true;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred during the hotel deletion process");
                throw;
            }
        }
    }
}
