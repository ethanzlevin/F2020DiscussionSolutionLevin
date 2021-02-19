using F2020DiscussionAppLevin.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace F2020DiscussionAppLevin.Models // database connection
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
           List<Pet> pets = database.Pet.Include(p => p.Client).Include(p => p.VoucherRequestForPet).ToList();
            return pets;
        }

        public int AddPet(Pet pet)
        {
            database.Pet.Add(pet);
            database.SaveChanges();
            return pet.PetID;
        }

        public void EditPet(Pet pet)
        {

            database.Pet.Update(pet);
            database.SaveChanges();
        }

        public Pet FindPet(int petID)
        {
            Pet pet = database.Pet.Find(petID);
            return pet;
        }
    }
}
