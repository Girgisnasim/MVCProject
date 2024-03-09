using Microsoft.AspNetCore.Mvc;
using MVCProject.Repositories;

namespace MVCProject.Controllers
{
    public class TicketsController : Controller
    {
        private ITicketsRepo ticketRepo;
        public TicketsController(ITicketsRepo ticketRepo)
        {
            this.ticketRepo = ticketRepo;
        }

        // to show all of tickets available
        public IActionResult getAll()
        {
            return View();
        }
        //Add ticket
        public IActionResult AddTicket()
        {
            return View();
        }
    }
}
