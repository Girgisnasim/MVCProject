using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVCProject.Models;
using MVCProject.Repositories;

namespace MVCProject.Controllers
{
    public class TripController : Controller
    {
        private ITripsRepo tripsRepo;
        public TripController(ITripsRepo tripsRepo)
        {
            this.tripsRepo = tripsRepo;
        }
        public IActionResult Stations()
        {
            ViewBag.Trip = tripsRepo.GetLoctions();
            SelectList tripsLoction=new SelectList(ViewBag.Trip);
            return View(tripsLoction);
        }
        public IActionResult GetStation(string name1) 
        {
            List<Trip> trips= tripsRepo.GetStation(name1);
            return PartialView("_Stationpartial",trips);
        }
    }
}
