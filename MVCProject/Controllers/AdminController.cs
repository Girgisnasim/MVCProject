
﻿using Microsoft.AspNetCore.Hosting;

﻿using Microsoft.AspNetCore.Authorization;
using MVCProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using MVCProject.Models;
using MVCProject.Repositories;

namespace MVCProject.Controllers
{
    [Authorize]
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
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Add() {
         return View();
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]

        public async Task<IActionResult> AddAsync(TripVM tripVM, IFormFile image)
        {
            if (!ModelState.IsValid)
            {
                // If model validation fails, return to the view with errors
                return View(tripVM);
            }

            //Check if image is provided and its length is greater than 0

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

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await image.CopyToAsync(fileStream);
            }

            tripVM.image = image.FileName;
            Trip trip= new Trip()
            {
                Name = tripVM.Name,
                Location = tripVM.Location,
                Price = tripVM.Price,
                Status = tripVM.Status,
                Available_Seats = tripVM.Available_Seats,
                Total_Seats = tripVM.Total_Seats,
                Arrival_Time = tripVM.Arrival_Time,
                Departure_Time = tripVM.Departure_Time,
                Departure_Date = tripVM.Departure_Date,
                image = tripVM.image
            };
            AdminRepo.Add(trip);

            return RedirectToAction("Getall");
        }




        [Authorize(Roles = "Admin")]
        public ActionResult update(int id)
        {

            Trip trip = AdminRepo.Get(id);
            if (trip == null)
            {
                return NotFound();
            }
            return View(trip);

        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult update(Trip trip) {

            AdminRepo.Update(trip);
            return RedirectToAction("Getall");

        }
        [Authorize(Roles = "Admin")]
        public ActionResult delete(int id)
        {
            AdminRepo.Delete(id);
            return RedirectToAction("Getall");
        }
       
    }
}
