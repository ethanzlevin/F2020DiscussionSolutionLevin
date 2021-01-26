using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using F2020DiscussionAppLevin.Data;
using F2020DiscussionAppLevin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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


        //public IActionResult SearchForPetsUserInput()
        //{
        //    //Dynamic drop down list of clients from DB

        //    ViewData["AllClients"] = new SelectList(iPetRepo.ListAllClients(), "Id" , "Fullname" ); /*list of items, value returned, text(what we show)*/  

        //    SearchForPetsViewModel searchForPetsViewModel = new SearchForPetsViewModel();

        //    return View(searchForPetsViewModel);
        //}


        public IActionResult SearchForPets(SearchForPetsViewModel viewModel)/*(string clientID, string petType, DateTime? startDate, DateTime? endDate)*/
        {

            ViewData["AllClients"] = new SelectList(iPetRepo.ListAllClients(), "Id", "Fullname"); /*list of items, value returned, text(what we show)*/


            List<Pet> searchList = iPetRepo.ListAllPets();
            if (!string.IsNullOrEmpty(viewModel.ClientID))
            { searchList = searchList.Where(p => p.ClientID == viewModel.ClientID).ToList(); }
            if (!string.IsNullOrEmpty(viewModel.PetType))
            {
                searchList = searchList.Where(p => p.PetType == viewModel.PetType).ToList();

            }
            if (viewModel.StartDate.HasValue)
            { searchList = searchList.Where(p => p.VoucherRequestForPet.Any(vr => vr.DecisionDate >= viewModel.StartDate.Value.Date)  ).ToList(); }

            if (viewModel.EndDate.HasValue)
            { searchList = searchList.Where(p => p.VoucherRequestForPet.Any(vr => vr.DecisionDate <= viewModel.EndDate.Value.Date)).ToList(); }
          
            //assign
            viewModel.ResultPetList = searchList;


            return View(viewModel);
        }
    }
}
