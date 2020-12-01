using F2020DiscussionAppLevin.Models;
using Microsoft.AspNetCore.Identity;
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

        //three services
        //1 dbservice
        public static void Initialize(IServiceProvider services)
        {
            ApplicationDbContext database = services.GetRequiredService<ApplicationDbContext>();

            //2. role service
            //in startup.cs
            //.AddRoles<IdentityRole>()
            RoleManager<IdentityRole> roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

            //3. User service
            //on startup change on line 33 Identity User to ApplicationUser and on loginpartial
            UserManager<ApplicationUser> userManager = services.GetRequiredService<UserManager<ApplicationUser>>();



            string clientRole = "Client";
            string volunteerRole = "Volunteer";
            string administratorRole = "Administrator";
            if (!database.Roles.Any())
            {
                IdentityRole role = new IdentityRole(clientRole);
                roleManager.CreateAsync(role).Wait();

                role = new IdentityRole(volunteerRole);
                roleManager.CreateAsync(role).Wait();

                role = new IdentityRole(administratorRole);
                roleManager.CreateAsync(role).Wait();
            }


            if (!database.ApplicationUser.Any())
            {

                Client client = new Client("Test", "Client1", "1 street road", "888888888", "TestClient1@test.com", "TestClient1");
                userManager.CreateAsync(client).Wait();
                userManager.AddToRoleAsync(client, clientRole).Wait();

                client = new Client("Test", "Client2", "2 street road", "988888888", "TestClient2@test.com", "TestClient2");
                userManager.CreateAsync(client).Wait();
                userManager.AddToRoleAsync(client, clientRole).Wait();

               Volunteer volunteer = new Volunteer("Test", "Volunteer1", "3 street road", "898888888", "TestVolunteer1@test.com", "TestVolunteer1", 10);
                userManager.CreateAsync(volunteer).Wait();
                userManager.AddToRoleAsync(volunteer, volunteerRole).Wait();
                userManager.AddToRoleAsync(volunteer, administratorRole).Wait();

                volunteer = new Volunteer("Test", "Volunteer2", "4 street road", "998888888", "TestVolunteer2@test.com", "TestVolunteer2", 20);
                userManager.CreateAsync(volunteer).Wait();
                userManager.AddToRoleAsync(volunteer, volunteerRole).Wait();

                ApplicationUser applicationUser = new ApplicationUser("Test", "Administrator 1", "5 street road", "563738232", "TestAdmin@test.com","AdminTest");
                userManager.CreateAsync(applicationUser).Wait();
                userManager.AddToRoleAsync(applicationUser, administratorRole).Wait();

            }


            if (!database.Pet.Any())
            {
                DateTime? dateOfBirth = new DateTime(2015, 6, 15);

                //LINQ's Lambda Expression (C# queries)
                Client client = database.Client.Where(c => c.Email == "TestClient1@test.com").FirstOrDefault();
                string clientID = client.Id;

                //fk violation Client ID does not exist as a PK in ApplicationUSER= id
                Pet pet = new Pet("Spot", "Dog", "Male", dateOfBirth, "Large", clientID);
                database.Pet.Add(pet);
                database.SaveChanges();

                dateOfBirth = null;
                pet = new Pet("Lady", "Cat", "Female", dateOfBirth, "null", clientID);
                database.Pet.Add(pet);
                database.SaveChanges();

                client = database.Client.Where(c => c.Email == "TestClient2@test.com").FirstOrDefault();
                clientID = client.Id;

                dateOfBirth = new DateTime(2012, 3, 24);
                pet = new Pet("Zeus", "Dog", "Male", dateOfBirth, "Medium", clientID);
                database.Pet.Add(pet);
                database.SaveChanges();

                dateOfBirth = null;
                pet = new Pet("Garfield", "Cat", "Male", dateOfBirth, "null", clientID);
                database.Pet.Add(pet);
                database.SaveChanges();

                dateOfBirth = new DateTime(2019, 2, 15);
                pet = new Pet("Melly", "Dog", "Female", dateOfBirth, "null", clientID);
                database.Pet.Add(pet);
                database.SaveChanges();
            }

            if (!database.VoucherRequest.Any())
            {
                VoucherRequest voucherRequest = new VoucherRequest("Approved", 2);
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

            if (!database.Fund.Any())
            {
                Fund fund = new Fund("test", "test",100);
                database.Fund.Add(fund);
                database.SaveChanges();

                fund = new Fund("test2", "test", 100);
                database.Fund.Add(fund);
                database.SaveChanges();
                fund = new Fund("test3", "test", 100);
                database.Fund.Add(fund);
                database.SaveChanges();
                fund = new Fund("test4", "test", 100);
                database.Fund.Add(fund);
                database.SaveChanges();
                fund = new Fund("test5", "test", 100);
                database.Fund.Add(fund);
                database.SaveChanges();
            }


            if (!database.FundCriteria.Any())
            {
                FundCriteria fundCriteria = new FundCriteria(1,"Mon");
                database.FundCriteria.Add(fundCriteria);
                database.SaveChanges();

                Fund fund = database.Fund.Find(1);
                fund.FundCriteriaID = 1;
                database.Fund.Update(fund);
                database.SaveChanges();

                fundCriteria = new FundCriteria(2,"Boone");
                database.FundCriteria.Add(fundCriteria);
                database.SaveChanges();

                fund = database.Fund.Find(2);
                fund.FundCriteriaID = 2;
                database.Fund.Update(fund);
                database.SaveChanges();

                fundCriteria = new FundCriteria(3,"Mon");
                database.FundCriteria.Add(fundCriteria);
                database.SaveChanges();

                fund = database.Fund.Find(3);
                fund.FundCriteriaID = 3;
                database.Fund.Update(fund);
                database.SaveChanges();


            }

            if (!database.FundforVoucher.Any())
            {
                FundforVoucher fundforVoucher = new FundforVoucher(1,1,10);
                database.FundforVoucher.Add(fundforVoucher);
                database.SaveChanges();

               


                fundforVoucher = new FundforVoucher(2, 2, 10);
                database.FundforVoucher.Add(fundforVoucher);
                database.SaveChanges();

                fundforVoucher = new FundforVoucher(2, 2, 10);
                database.FundforVoucher.Add(fundforVoucher);
                database.SaveChanges();



            }








        }
    }
}
