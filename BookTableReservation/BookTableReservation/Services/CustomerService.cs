using BookTableReservation.Data;
using BookTableReservation.Entities;
using BookTableReservation.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BookTableReservation.Services
{
    public class CustomerService : ICustomerService
    {

        private readonly ICustomerRepository customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {

            this.customerRepository = customerRepository;
        }

        public async Task<Customer> GetCustomerByIdAsync(int customerId)
        {
            return  await customerRepository.GetById(customerId);
        }
    }
}
