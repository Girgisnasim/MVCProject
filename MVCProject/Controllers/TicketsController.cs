using Microsoft.AspNetCore.Mvc;
using MVCProject.Models;
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
        public IActionResult GetTrip(int id)
        {
            return View(ticketRepo.showTicket(id));
        }
        //Add ticket
        public IActionResult AddTicket(Ticket ticket)
        {
            ticketRepo.Add(ticket);
            return RedirectToAction("Stations","Trip");
        }
    }
}
