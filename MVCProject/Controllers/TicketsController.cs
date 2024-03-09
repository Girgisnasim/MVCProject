using Microsoft.AspNetCore.Mvc;

namespace MVCProject.Controllers
{
    public class TicketsController : Controller
    {
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
