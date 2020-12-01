using F2020DiscussionAppLevin.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace F2020DiscussionAppLevin.Models
{
    public class PetRepo : IPetRepo
    {
        private ApplicationDbContext database;
        

        // dependancy injection
        public PetRepo(ApplicationDbContext dbContext)
        {
            this.database = dbContext;
        }

        public List<Pet> ListAllPets()
        {
           List<Pet> pets = database.Pet.Include(p => p.VoucherRequestForPet).ToList();
            return pets;
        }
    }
}
