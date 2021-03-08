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
           List<Pet> pets = database.Pet
                .Include(p => p.Client)
                .Include(p => p.VoucherRequestForPet)
                .ThenInclude(vr => vr.DecisionMaker)
                .ToList();
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

        public Pet FindPet(int? petID)
        {
            Pet pet = database.Pet.Find(petID);
            return pet;
        }

        public double FindRequestAmount(int petID)
        {
            Pet pet = FindPet(petID);
            double requestAmount;

            if (pet.PetType == "Cat")
            {
                if (pet.PetGender == "Male")
                {
                    requestAmount = 60.00;
                }
                else
                {
                    requestAmount = 50.00;
                }
            }
            else
            {
                if (pet.PetGender == "Male")
                {
                   if(pet.PetSize == "Small")
                    {
                        requestAmount = 100.00;
                    }
                   if(pet.PetSize == "Medium")
                    {
                        requestAmount = 110.00;
                    }
                   else
                    {
                        requestAmount = 120.00;
                    }
                }
                else
                {
                    if (pet.PetSize == "Small")
                    {
                        requestAmount = 70.00;
                    }
                    if (pet.PetSize == "Medium")
                    {
                        requestAmount = 80.00;
                    }
                    else
                    {
                        requestAmount = 90.00;
                    }
                }

            }
            return requestAmount;

        }

        public void DeletePet(Pet pet)
        {
            database.Pet.Remove(pet);
            database.SaveChanges();
        }
    }
}
