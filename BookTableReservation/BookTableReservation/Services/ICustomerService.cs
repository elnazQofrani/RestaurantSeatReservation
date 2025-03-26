using BookTableReservation.Entities;

namespace BookTableReservation.Services
{
    public interface ICustomerService
    {
        Task<Customer> GetCustomerByIdAsync(int customerId);
    }
}
