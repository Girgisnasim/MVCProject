using Microsoft.AspNetCore.Mvc;
using MVCProject.Models;
using MVCProject.Repositories;

namespace MVCProject.Controllers
{
    public class CustomerController : Controller
    {
        private ICustomerRepo customerRepo;
        public CustomerController(ICustomerRepo customerRepo)
        {
            this.customerRepo = customerRepo;
        }

        //show all booking ticket for this customer
        public IActionResult BookedTickets() 
        {  
            return View(customerRepo.GetAll());
        }
        
        //get by id =>Details or profile page
        public IActionResult profile(int id)
        {
            return View();
        }


        //Delete ticket
        public IActionResult DeleteTicket()
        {
            return View();
        }



    }
}
