using AutoMapper;
using Azure.Core;
using BookTableReservation.Entities;
using BookTableReservation.Models;
using BookTableReservation.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookTableReservation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper mapper;

        public CustomerController(ICustomerRepository _customerRepository, IMapper mapper)
        {
            this._customerRepository = _customerRepository;
            this.mapper = mapper;
        }

        [HttpPost]

        public async Task<IActionResult> Create([FromBody] CustomerAddDto customerDto)
        {

            if (customerDto == null)
                return BadRequest("Invalid Customer data.");

            var customerList = mapper.Map<Customer>(customerDto);
            try
            {
                var result = await _customerRepository.CreatAsync(customerList);

                return Ok(new { CustomerId = result.Id });

            }
            catch   (Exception ex)
            {
         
                return StatusCode( 500, ex.Message);
            }

        }

    }
}
