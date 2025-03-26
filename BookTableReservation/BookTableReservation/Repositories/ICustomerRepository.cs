using BookTableReservation.Entities;

namespace BookTableReservation.Repositories
{
    public interface ICustomerRepository
    {
        Task<Customer> CreatAsync(Customer customer);
        Task<Customer> GetById(int Id);
          
    }
}
