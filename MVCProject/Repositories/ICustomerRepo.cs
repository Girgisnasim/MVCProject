using MVCProject.Models;

namespace MVCProject.Repositories
{
    public interface ICustomerRepo
    {
        //get by id
        public Customer GetById(int id);


    }
}
