using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using F2020DiscussionAppLevin.Data;
using F2020DiscussionAppLevin.Models;
using Microsoft.AspNetCore.Mvc;

namespace F2020DiscussionAppLevin.Controllers
{
    public class PetController : Controller
    {

        //instance variable
        private ApplicationDbContext database;
        // dependancy injection
        public PetController(ApplicationDbContext dbContext)
        {

            this.database = dbContext;
        }
        public IActionResult ListAllPets()
        {
            List<Pet> allPets = database.Pet.ToList();
            return View(allPets);
        }
    }
}
