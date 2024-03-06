using FluentValidation;
using HotelService.Application.Features.Commands.Contact.RemoveContactInfoFromHotel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelService.Application.Validations.Contact
{
    public class RemoveContactInfoFromHotelCommandValidator:AbstractValidator<RemoveContactInfoFromHotelCommand>
    {
        public RemoveContactInfoFromHotelCommandValidator()
        {
            RuleFor(x => x.ContactId)
             .NotEmpty()
             .WithMessage("{PropertyName} cannot be empty");
        }
    }
}
