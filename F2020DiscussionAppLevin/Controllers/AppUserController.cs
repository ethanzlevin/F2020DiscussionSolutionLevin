using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using F2020DiscussionAppLevin.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace F2020DiscussionAppLevin.Controllers
{
    public class AppUserController : Controller
    {
        private IApplicationUserRepo iApplicationUserRepo;
        private UserManager<ApplicationUser> userManager;
        public AppUserController(IApplicationUserRepo applicationUserRepo, UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
            this.iApplicationUserRepo = applicationUserRepo;
        }

        [HttpGet]
        public IActionResult AssignAppUserRoles()
        {
            ViewData["AppUsers"] = new SelectList(iApplicationUserRepo.ListAllAppUsers(),"Id" ,"Fullname");
            return View();
        }

        [HttpPost]
        public IActionResult AssignAppUserRoles(string submitButton, string ddlAppUsers, List<string> currentRoles, List<string> availableRoles)
        {
            
            ApplicationUser user = iApplicationUserRepo.FindApplicationUser(ddlAppUsers);

            if(submitButton == "AddRoles")
            {
                    userManager.AddToRolesAsync(user, availableRoles).Wait();
            }
            if (submitButton == "RemoveRoles")
            {
                userManager.RemoveFromRolesAsync(user, currentRoles).Wait();
            }
           
                ViewData["AppUsers"] = new SelectList(iApplicationUserRepo.ListAllAppUsers(), "Id", "Fullname", ddlAppUsers);
                return View();
            
        }


        //json data
        public string GetCurrentRoles(string id)
        {
           return iApplicationUserRepo.GetCurrentRoles(id);
        }

        public string GetAvailableRoles(string id)
        {
            return iApplicationUserRepo.GetAvailableRoles(id);
        }

    }
}
