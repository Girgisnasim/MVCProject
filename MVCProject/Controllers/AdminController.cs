using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVCProject.Models;
using MVCProject.Repositories;

namespace MVCProject.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
       private IAdminRepo AdminRepo;
        public AdminController(IAdminRepo _adminRepo)
        {
            AdminRepo =_adminRepo;
        }
        public IActionResult Getall()
        {
            List<Trip> trips=AdminRepo.Getall();
            return View(trips);
        }
        public IActionResult Add() {
         return View();
        }
        [HttpPost]
        public IActionResult Add(Trip trip)
        {
            AdminRepo.Add(trip);
            return RedirectToAction("Getall");
        }
        public ActionResult update(int id)
        {

            Trip trip = AdminRepo.Get(id);
            if (trip == null)
            {
                return NotFound();
            }
            return View(trip);

        }
        [HttpPost]
        public ActionResult update(Trip trip) {

            AdminRepo.Update(trip);
            return RedirectToAction("Getall");

        }
        public ActionResult delete(int id)
        {
            AdminRepo.Delete(id);
            return RedirectToAction("Getall");
        }
       
    }
}
