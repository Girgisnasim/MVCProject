using MVCProject.Models;

namespace MVCProject.Repositories
{
    public class CustomerRepo : ICustomerRepo
    {
        private BookContext context;

        public CustomerRepo(BookContext context)
        {
            this.context = context;
        }

        public Customer GetById(int id)
        {
            Customer customer = context.customers.SingleOrDefault(x => x.Id == id);
            return customer;
        }
    }
}
