using F2020DiscussionAppLevin.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace F2020DiscussionAppLevin.Data
{
    public class DbInitializer
    {
        //method signature = accessType returnType Method name (parameterType param1, paramType param2) // number, dataType, order
        public static void Initialize(IServiceProvider services)
        {
            ApplicationDbContext database = services.GetRequiredService<ApplicationDbContext>();

            

            if (!database.Pet.Any())  //does pet table have any data
            {
                DateTime? dateOfBirth = new DateTime(2015, 6, 15);
                Pet pet = new Pet("Spot", "Dog", "Male", dateOfBirth, "Large");
                database.Pet.Add(pet);
                database.SaveChanges();

                dateOfBirth = null;
                pet = new Pet("Lady", "Cat", "Female", dateOfBirth, "null");
                database.Pet.Add(pet);
                database.SaveChanges();

                dateOfBirth = new DateTime(2012, 3, 24);
                pet = new Pet("Zeus", "Dog", "Male", dateOfBirth, "Medium");
                database.Pet.Add(pet);
                database.SaveChanges();

                dateOfBirth = null;
                pet = new Pet("Garfield", "Cat", "Male", dateOfBirth, "null");
                database.Pet.Add(pet);
                database.SaveChanges();

                dateOfBirth = new DateTime(2019, 2, 15);
                pet = new Pet("Melly", "Dog", "Female", dateOfBirth, "null");
                database.Pet.Add(pet);
                database.SaveChanges();
            }

            if(!database.VoucherRequest.Any())
            {
                VoucherRequest voucherRequest = new VoucherRequest("Approved", 1);
                database.VoucherRequest.Add(voucherRequest);
                database.SaveChanges();

                voucherRequest = new VoucherRequest("Pending", 2);
                database.VoucherRequest.Add(voucherRequest);
                database.SaveChanges();
                

                voucherRequest = new VoucherRequest("Denied", 3);
                database.VoucherRequest.Add(voucherRequest);
                database.SaveChanges();

                voucherRequest = new VoucherRequest("Approved", 3);
                database.VoucherRequest.Add(voucherRequest);
                database.SaveChanges();

                voucherRequest = new VoucherRequest("Denied", 4);
                database.VoucherRequest.Add(voucherRequest);
                database.SaveChanges();

                voucherRequest = new VoucherRequest("Approved", 4);
                database.VoucherRequest.Add(voucherRequest);
                database.SaveChanges();

                voucherRequest = new VoucherRequest("Pending", 5);
                database.VoucherRequest.Add(voucherRequest);
                database.SaveChanges();
            }
        }


    }
}
