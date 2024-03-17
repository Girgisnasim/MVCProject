using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVCProject.Models;
using MVCProject.ViewModels;

namespace MVCProject.Controllers
{

    [Authorize(Roles = "Admin")]
    public class RolesController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManger;

        public RolesController(RoleManager<IdentityRole> roleManger)
        {
            this.roleManger = roleManger;
        }

        [HttpGet]
      public IActionResult New()
        {
            return View();
        }


        [HttpPost]
        public async Task< IActionResult> New(RoleViewModel newRoleVM )
        {

            if (ModelState.IsValid)
            {
                IdentityRole role = new IdentityRole();
                role.Name = newRoleVM.RoleName;
               IdentityResult result= await roleManger.CreateAsync(role);
                if (result.Succeeded)
                {
                    return View(new RoleViewModel());
                }
                foreach(var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
            
            return View(newRoleVM);
        }

    }
}
