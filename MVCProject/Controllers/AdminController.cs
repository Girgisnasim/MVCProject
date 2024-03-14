using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using MVCProject.Models;
using MVCProject.Repositories;

namespace MVCProject.Controllers
{
    public class AdminController : Controller
    {
       private IAdminRepo AdminRepo;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public AdminController(IAdminRepo _adminRepo, IWebHostEnvironment webHostEnvironment)
        {
            AdminRepo =_adminRepo;
            _webHostEnvironment = webHostEnvironment;
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
        public async Task<IActionResult> AddAsync(Trip trip, IFormFile image)
        {
            if (image == null || image.Length == 0)
            {
                ModelState.AddModelError("image", "Please select a file to upload.");
                return RedirectToAction("Error");
            }

            var uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            var fileName = Path.GetFileName(image.FileName);
            var filePath = Path.Combine(uploadsFolder, fileName);

            if (System.IO.File.Exists(filePath))
            {
                ModelState.AddModelError("image", "A file with the same name already exists.");
                return RedirectToAction("Error");
            }

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await image.CopyToAsync(fileStream);
            }

            trip.image =image.FileName;

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
