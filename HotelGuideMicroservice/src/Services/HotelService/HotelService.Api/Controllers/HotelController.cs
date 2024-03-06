using HotelService.Application.Features.Commands.Hotel.CreateHotel;
using HotelService.Application.Features.Queries.Hotel.GetHotelDetails;
using HotelService.Domain.DTOs;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IMediator _mediator;

        public HotelController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        [Route("{Id:guid}")]
        public async Task<IActionResult> GetById([FromRoute] GetHotelDetailsQuery request)
        {
            var result = await _mediator.Send(request);
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateHotelCommand request)
        {

            var createHotelDto = new CreateHotelDTO
            {
                AuthorizedPersonFirstName = request.CreateHotelDto.AuthorizedPersonFirstName,
                AuthorizedPersonLastName = request.CreateHotelDto.AuthorizedPersonLastName,
                CompanyTitle = request.CreateHotelDto.CompanyTitle
            };
            var hotelDto = await _mediator.Send(new CreateHotelCommand(createHotelDto));
            return Ok(hotelDto);
        }
    }
}
