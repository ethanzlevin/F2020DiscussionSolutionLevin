using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using F2020DiscussionAppLevin.Data;
using F2020DiscussionAppLevin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace F2020DiscussionAppLevin.Controllers
{
    public class PetController : Controller
    {

        //Seperation of concerns
        //M data layer
        //C business logic
        // v UI

        // Controller <-> Database
        //UI (View) <-> Controller


        //instance variable
        //private ApplicationDbContext database;     //replace dependancy on databse by using Interface obj
        private IPetRepo iPetRepo; 

        // dependancy injection
        public PetController(IPetRepo petRepo)
            //ApplicationDbContext dbContext)
        {
            this.iPetRepo = petRepo;
            //this.database = dbContext;
        }
        [Authorize(Roles = "Volunteer, Administrator")]
        //Interface - Class
        public IActionResult ListAllPets()
        {

            //Select * from Pets in sql
            List<Pet> allPets = iPetRepo.ListAllPets(); //database.Pet.Include(p => p.VoucherRequestForPet).ToList();

            return View(allPets);
        }

        public IActionResult SearchForPets(string clientID, string petType)
        {
            
            List<Pet> searchList = iPetRepo.ListAllPets();
            searchList = searchList.Where(p => p.ClientID == clientID).ToList();
            if (!string.IsNullOrEmpty(petType))
            {
                searchList = searchList.Where(p => p.PetType == petType).ToList();

            }
            return View(searchList);
        }
    }
}
