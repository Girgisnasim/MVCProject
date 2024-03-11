using Microsoft.AspNetCore.Mvc;
using MVCProject.Models;
using MVCProject.Repositories;

namespace MVCProject.Controllers
{
    public class CustomerController : Controller
    {
        private ICustomerRepo customerRepo;
        private ITicketsRepo ticketsRepo;
        public CustomerController(ICustomerRepo customerRepo,ITicketsRepo ticketsRepo)
        {
            this.customerRepo = customerRepo;
            this.ticketsRepo = ticketsRepo;
        }
        
        //get by id =>Details or profile page
        public IActionResult profile(int id)
        {
            List<Ticket> ticketList = ticketsRepo.GetTicketsOfUser(id);
            ViewBag.TicketsOfUser=ticketList;
            return View(customerRepo.GetById(id));
        }

    }
}
