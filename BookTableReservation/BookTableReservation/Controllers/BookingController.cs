using AutoMapper;
using Azure.Core;
using BookTableReservation.Entities;
using BookTableReservation.Enums;
using BookTableReservation.Models;
using BookTableReservation.Repositories;
using BookTableReservation.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookTableReservation.Controllers
{
    
    //Serilog
    /// <summary>
    /// https://github.com/MeladKamari/Melad.Common/blob/master/Directory.Packages.props
    /// </summary>
    ///
    /// Scrutor
    ///
    ///   <PackageVersion Include="Serilog" Version="3.1.1" />
    // <PackageVersion Include="Serilog.Settings.Configuration" Version="8.0.0" />
    // <PackageVersion Include="Serilog.AspNetCore" Version="8.0.1" />
    // <PackageVersion Include="Serilog.Sinks.Console" Version="5.0.1" />
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IMapper mapper;
        private readonly ICustomerService _customerService;
        private readonly ISeatService _seatService;
        public BookingController(IBookingRepository _bookingRepository, IMapper mapper, ICustomerService _customerService, ISeatService _seatService)
        {

            this._bookingRepository = _bookingRepository;
            this.mapper = mapper;
            this._customerService = _customerService;
            this._seatService = _seatService;
        }

        // https://github.com/MeladKamari/Melad.Common
        //Fluent Validation
        // https://fluentvalidation.net/
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] BookingDto bookingDto)
        {
            if (bookingDto == null)
                return BadRequest("Invalid request data.");

            var customer = await _customerService.GetCustomerByIdAsync(bookingDto.CustomerId);
            if (customer == null)
                return NotFound("Customer not found.");
            var isSeatAvailable = await _seatService.IsSeatsAvailable(bookingDto.SeatId, bookingDto.BookingDateTime, bookingDto.StartTime);
            if (!isSeatAvailable)
                return BadRequest("Seat is pre booked");
            var booking = mapper.Map<Booking>(bookingDto);
            booking.SetBookingStatus(BookingStatus.Confirmed);
            var result = await _bookingRepository.CreatAsync(booking);
            return Ok(new { Message = "Seat booked successfully", BookingId = result.Id });
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetBookingById([FromRoute] int id)
        {
            var booking = await _bookingRepository.GetById(id);
            if (booking == null)
            {
                return NotFound("Booking not found");
            }

            var bookingDto = mapper.Map<BookingDto>(booking);
            return Ok(bookingDto);
        }

        [HttpPut]
        [Route("{id:int}")]

        public async Task<IActionResult> UpdateBooking(int id, [FromBody] BookingDto bookingDto)
        {
            if (bookingDto == null)
            {
                return BadRequest("Invalid request.");
            }

            var booking = await _bookingRepository.GetById(id);
            if (booking == null)
            {
                return NotFound("Booking not found");
            }

            await _bookingRepository.Update(booking);

            return Ok(new { Message = "Booking updated successfully", BookingId = booking.Id });
        }


        [HttpPatch]
        [Route("{id:int}")]
        public async Task<IActionResult> CancelBooking([FromRoute] int id)
        {

            var booking = await _bookingRepository.GetById(id);
            if (booking == null)
                return NotFound("Booking not found");

            if (booking.Status == BookingStatus.Canceled)
                return BadRequest("This booking is already canceled.");


            booking.Status = BookingStatus.Canceled;

            await _bookingRepository.Update(booking);

            return Ok(new { Message = "Booking canceled successfully", BookingId = booking.Id });
        }
    }

}

