using HotelService.Application.Features.Commands.Hotel.RemoveHotel;
using HotelService.Domain.Repository;
using HotelService.Domain.UnitOfWorks;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelService.Application.Features.Commands.Contact.RemoveContactInfoFromHotel
{
    public class RemoveContactInfoFromHotelCommandHandler : IRequestHandler<RemoveContactInfoFromHotelCommand, bool>
    {
        private readonly IContactRepository _contactRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<RemoveHotelCommandHandler> _logger;

        public RemoveContactInfoFromHotelCommandHandler(IContactRepository contactRepository, IUnitOfWork unitOfWork, ILogger<RemoveHotelCommandHandler> logger)
        {
            _contactRepository = contactRepository;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<bool> Handle(RemoveContactInfoFromHotelCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingContact = await _contactRepository.GetByIdAsync(request.ContactId);
                if (existingContact == null)
                {
                    _logger.LogWarning($"The contact with ID - {request.ContactId} could not be found.");
                    return false;
                }

                _contactRepository.Remove(existingContact);
                await _unitOfWork.CommitAsync();
                return true;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred during the contact deletion process");
                throw;
            }
        }
    }
}
