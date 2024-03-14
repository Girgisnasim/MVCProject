using Microsoft.AspNetCore.Mvc;
using MVCProject.Models;
using MVCProject.Repositories;
using System.Numerics;

namespace MVCProject.Controllers
{
    public class PlanController : Controller

    {   private IPlanRepo planRepo;
        public PlanController(IPlanRepo planRepo)
        {
           this.planRepo = planRepo;
        }


        public IActionResult Getall()
        {
            List<Plan> plan = planRepo.Getall();
            return View(plan);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Plan plan)
        {
            planRepo.Add(plan);

            return RedirectToAction("Getall");
        }

        public ActionResult update(int id)
        {

            Plan plan = planRepo.Get(id);
            if (plan == null)
            {
                return NotFound();
            }
            return View(plan);

        }

        [HttpPost]
        public ActionResult update(Plan plan)
        {

            planRepo.Update(plan);
            return RedirectToAction("Getall");

        }
        public ActionResult delete(int id)
        {
            planRepo.Delete(id);
            return RedirectToAction("Getall");
        }
    }
}
