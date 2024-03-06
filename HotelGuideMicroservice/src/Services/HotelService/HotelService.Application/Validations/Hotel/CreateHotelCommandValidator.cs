using FluentValidation;
using HotelService.Application.Features.Commands.Hotel.CreateHotel;
using HotelService.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelService.Application.Validations.Hotel
{
    public class CreateHotelCommandValidator:AbstractValidator<CreateHotelDTO>
    {
        public CreateHotelCommandValidator()
        {
            RuleFor(x => x.AuthorizedPersonFirstName)
                .NotNull()
                .WithMessage("{PropertyName} cannot be null")
                .NotEmpty()
                .WithMessage("{PropertyName} cannot be empty");

            RuleFor(x => x.AuthorizedPersonLastName)
                .NotNull()
                .WithMessage("{PropertyName} cannot be null")
                .NotEmpty()
                .WithMessage("{PropertyName} cannot be empty");

            RuleFor(x => x.CompanyTitle)
               .NotNull()
               .WithMessage("{PropertyName} cannot be null")
               .NotEmpty()
               .WithMessage("{PropertyName} cannot be empty");
        }
    }
}
