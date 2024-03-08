using Microsoft.AspNetCore.Mvc;

namespace MVCProject.Controllers
{
    public class AlaaController : Controller
    {
        public IActionResult Index()
        {
            return Content("WELCOME Alaa");
        }
    }
}
