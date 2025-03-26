using BookTableReservation.Data;
using BookTableReservation.Entities;

namespace BookTableReservation.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {

        private readonly DbProjectContext dbContext;

        public CustomerRepository(DbProjectContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Customer> CreatAsync(Customer customer)
        {
            await dbContext.Customer.AddAsync(customer);
            await dbContext.SaveChangesAsync();

            return  customer;
        }

        public async Task<Customer> GetById(int Id)
        {

            var customer = await dbContext.Customer.FindAsync(Id);
            return customer;

        }

    }
}
