using Microsoft.AspNetCore.Mvc;
using MVCProject.Models;

namespace MVCProject.Controllers
{
    public class CustomerController : Controller
    {

        //show all booking ticket for this customer
        public IActionResult BookedTickets() 
        {  
            return View();
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
