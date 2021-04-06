using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using F2020DiscussionAppLevin.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace F2020DiscussionAppLevin.Controllers
{
    public class AppUserController : Controller
    {
        private IApplicationUserRepo iApplicationUserRepo;
        public AppUserController(IApplicationUserRepo applicationUserRepo)
        {
            this.iApplicationUserRepo = applicationUserRepo;
        }

        [HttpGet]
        public IActionResult AssignAppUserRoles()
        {
            ViewData["AppUsers"] = new SelectList(iApplicationUserRepo.ListAllAppUsers(),"Id" ,"Fullname");
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
