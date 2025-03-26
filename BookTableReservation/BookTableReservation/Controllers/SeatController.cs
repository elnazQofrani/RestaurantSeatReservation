using AutoMapper;
using BookTableReservation.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BookTableReservation.Models;
using Azure.Core;

namespace BookTableReservation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeatController : ControllerBase
    {
        private readonly ISeatRepository _seatRepository;
        private readonly IMapper mapper;
        public SeatController(ISeatRepository _seatRepository, IMapper mapper)
        {
            this._seatRepository = _seatRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("{desiredDateTime:datetime}/{desiredStartTime}")]
        public async Task<IActionResult> GetAvailableSeats([FromRoute] DateTime desiredDateTime, [FromRoute] string desiredStartTime)
        {
            if (!TimeSpan.TryParse(desiredStartTime, out TimeSpan startTime))
                return BadRequest("Invalid start time format.");

            var AvailableSeats = await _seatRepository.GetAvailableSeats(desiredDateTime, startTime);

            if (AvailableSeats == null || !AvailableSeats.Any()) return NotFound();
            return Ok(mapper.Map<List<SeatsDto>>(AvailableSeats));
        }

    }
}
