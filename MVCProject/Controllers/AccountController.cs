﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVCProject.Models;
using MVCProject.ViewModels;
using System.Security.Claims;

namespace MVCProject.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInMAnager;

        public AccountController
            (UserManager<ApplicationUser> _UserManager,
            SignInManager<ApplicationUser> _SignInMAnager)
        {
            userManager = _UserManager;
            signInMAnager = _SignInMAnager;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult AddAdmin()
        {
            return View();

        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task< IActionResult> AddAdmin(RegisterUserViewModel newUserVM)
        {
            if (ModelState.IsValid)
            {
                //create account
                ApplicationUser userModel = new ApplicationUser();
                userModel.UserName = newUserVM.UserName;
                userModel.PasswordHash = newUserVM.Password;
                userModel.Address = newUserVM.Address;
                IdentityResult result = await userManager.CreateAsync(userModel, newUserVM.Password);
                if (result.Succeeded == true)
                {

                await userManager.AddToRoleAsync(userModel, "Admin");
                    //creat cookie
                    await signInMAnager.SignInAsync(userModel, false);
                    return RedirectToAction("Getall", "Admin");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }

            }
            return View(newUserVM);

        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel UserVm)
        {
            if (ModelState.IsValid)
            {
                //check
                ApplicationUser userModel = await userManager.FindByNameAsync(UserVm.UserName);
                if (userModel != null)
                {
                    bool found = await userManager.CheckPasswordAsync(userModel, UserVm.Password);
                    if (found)
                    {
                        //    await signInMAnager.SignInAsync(userModel, UserVm.RememberMe);
                        List<Claim> Claims = new List<Claim>();
                        Claims.Add(new Claim("Address", userModel.Address));
                        await signInMAnager.SignInWithClaimsAsync
                            (userModel, UserVm.RememberMe, Claims);
                        IList<string> roles = await userManager.GetRolesAsync(userModel);
                        if (roles.Contains("Admin"))
                        {
                            // Redirect to Admin's view
                            return RedirectToAction("Getall", "Admin");
                        }
                        else
                        {
                            // Redirect to User's view
                            return RedirectToAction("Stations", "Trip");
                        }
                    }
                }
                ModelState.AddModelError("", "Username and password invalid");
            }
            return View(UserVm);
        }
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Login(LoginViewModel UserVm)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        ApplicationUser userModel = await userManager.FindByNameAsync(UserVm.UserName);
        //        if (userModel != null)
        //        {
        //            bool found = await userManager.CheckPasswordAsync(userModel, UserVm.Password);
        //            if (found)
        //            {
        //                IList<string> roles = await userManager.GetRolesAsync(userModel);
        //                if (roles.Contains("Admin"))
        //                {
        //                    // Redirect to Admin's view
        //                    return RedirectToAction("Getall", "Admin");
        //                }
        //                else
        //                {
        //                    // Redirect to User's view
        //                    return RedirectToAction("Stations", "Trip");
        //                }
        //            }
        //        }
        //        ModelState.AddModelError("", "Username and password invalid");
        //    }
        //    return View(UserVm);
        //}
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Login(LoginViewModel UserVm)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        //check
        //        ApplicationUser userModel = await userManager.FindByNameAsync(UserVm.UserName);
        //        if (userModel != null)
        //        {
        //            bool found = await userManager.CheckPasswordAsync(userModel, UserVm.Password);
        //            if (found)
        //            {
        //                //    await signInMAnager.SignInAsync(userModel, UserVm.RememberMe);
        //                List<Claim> Claims = new List<Claim>();
        //                Claims.Add(new Claim("Address", userModel.Address));
        //                await signInMAnager.SignInWithClaimsAsync
        //                    (userModel, UserVm.RememberMe, Claims);
        //                return RedirectToAction("Stations", "Trip");
        //            }
        //        }
        //        ModelState.AddModelError("", "Username and password invalid");
        //    }
        //    return View(UserVm);
        //}


        [HttpGet]//<a href>
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]//<a href>
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterUserViewModel newUserVM)
        {
            if (ModelState.IsValid)
            {
                //create account
                ApplicationUser userModel = new ApplicationUser();
                userModel.UserName = newUserVM.UserName;
                userModel.PasswordHash = newUserVM.Password;
                userModel.Address = newUserVM.Address;
                IdentityResult result = await userManager.CreateAsync(userModel, newUserVM.Password);
                if (result.Succeeded == true)
                {
                    //creat cookie
                    await signInMAnager.SignInAsync(userModel, false);
                    return RedirectToAction("Stations", "Trip");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }

            }
            return View(newUserVM);
        }
        public async Task<IActionResult> Logout()
        {
            await signInMAnager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }
    }
}
