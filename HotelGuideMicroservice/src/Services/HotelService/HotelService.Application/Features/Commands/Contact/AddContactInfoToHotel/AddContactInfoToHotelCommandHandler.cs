using AutoMapper;
using HotelService.Domain.DTOs;
using HotelService.Domain.Models;
using HotelService.Domain.Repository;
using HotelService.Domain.UnitOfWorks;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelService.Application.Features.Commands.Contact.AddContactInfoToHotel
{
    public class AddContactInfoToHotelCommandHandler : IRequestHandler<AddContactInfoToHotelCommand, bool>
    {
        private readonly IContactRepository _contactRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<AddContactInfoToHotelCommandHandler> _logger;
        private readonly IMapper _mapper;

        public AddContactInfoToHotelCommandHandler(IContactRepository contactRepository, IUnitOfWork unitOfWork, ILogger<AddContactInfoToHotelCommandHandler> logger, IMapper mapper)
        {
            _contactRepository = contactRepository;
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<bool> Handle(AddContactInfoToHotelCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingHotel = await _contactRepository.GetByIdAsync(request.HotelUUID);
                if (existingHotel == null)
                {
                    _logger.LogWarning($"The hotel with ID - {request.HotelUUID} could not be found.");
                    return false;
                }
                var contact = new ContactDTO()
                {
                    HotelUUID = request.HotelUUID,
                    Type = request.Type,
                    Content = request.Content,
                };
                var contactMap  = _mapper.Map<ContactModel>(contact);
                _contactRepository.AddAsync(contactMap);
                
                await _unitOfWork.CommitAsync();

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while adding contact information.");
                throw;
            }
        }
    }
}
