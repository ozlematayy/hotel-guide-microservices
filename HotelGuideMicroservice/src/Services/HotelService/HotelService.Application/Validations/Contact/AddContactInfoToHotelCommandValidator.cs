using FluentValidation;
using HotelService.Application.Features.Commands.Contact.AddContactInfoToHotel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelService.Application.Validations.Contact
{
    public class AddContactInfoToHotelCommandValidator:AbstractValidator<AddContactInfoToHotelCommand>
    {
        public AddContactInfoToHotelCommandValidator()
        {
            RuleFor(x=>x.HotelUUID).NotEmpty();
            RuleFor(x => x.Content).NotEmpty();
       }
    }
}
