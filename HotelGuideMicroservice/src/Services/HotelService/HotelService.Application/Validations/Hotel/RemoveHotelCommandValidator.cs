using FluentValidation;
using HotelService.Application.Features.Commands.Hotel.RemoveHotel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelService.Application.Validations.Hotel
{
    public class RemoveHotelCommandValidator:AbstractValidator<RemoveHotelCommand>
    {
        public RemoveHotelCommandValidator()
        {
            RuleFor(x => x.HotelId)
               .NotEmpty()
               .WithMessage("{PropertyName} cannot be empty");
        }
    }
}
