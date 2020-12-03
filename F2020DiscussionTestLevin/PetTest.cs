using System;
using Xunit;
using F2020DiscussionAppLevin.Controllers;
using F2020DiscussionAppLevin.Data;
using Moq;
using F2020DiscussionAppLevin.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace F2020DiscussionTestLevin
{
    public class PetTest
    {
        //instance variable 
        private Mock<IPetRepo> mockPetRepo;
        [Fact]
        public void ShouldListAllPets()
        {
            //AA

            //1.Arrange
            //ApplicationDbContext database = null; controller does not use databse for testing
            
            mockPetRepo = new Mock<IPetRepo>();

            List<Pet> mockPets = CreateMockPetData();
            mockPetRepo.Setup(m => m.ListAllPets()).Returns(mockPets);

            int expectedNumofPetsInList = 3;

            PetController petController = new PetController(mockPetRepo.Object);
            ////2. Act
            
            ViewResult result = petController.ListAllPets() as ViewResult;
            List<Pet> resultModel = result.Model as List<Pet>;
            int actualNumOfPetsInList = resultModel.Count;

            //3.Assert


            Assert.Equal(expectedNumofPetsInList, actualNumOfPetsInList);

        }

        // four base db operations
        //crud
        //create (add)read (list all, search, find/get one object) update(Modify) delete(Remove)


        [Fact]
        public void ShouldSearchForPetsByOwner()
        {
            //arange
            mockPetRepo = new Mock<IPetRepo>();

            List<Pet> mockPets = CreateMockPetData();
            mockPetRepo.Setup(m => m.ListAllPets()).Returns(mockPets); //logic in controller method


            int expectedNumofPetsInList = 3;

            PetController petController = new PetController(mockPetRepo.Object);

            //dropdown list for owners (text =Full name of owner value = ID)
            string clientID = "001";
            string petType = null;



            //act

            ViewResult result = petController.SearchForPets(clientID, petType) as ViewResult;

            List<Pet> resultModel = result.Model as List<Pet>;

            int actualNumOfPetsInList = resultModel.Count;
            // Assert

            Assert.Equal(expectedNumofPetsInList, actualNumOfPetsInList);



        }

        [Fact]
        public void ShouldSearchForPetsByOwnerandPetType()
        {
            //arange
            mockPetRepo = new Mock<IPetRepo>();

            List<Pet> mockPets = CreateMockPetData();
            mockPetRepo.Setup(m => m.ListAllPets()).Returns(mockPets); //logic in controller method


            int expectedNumofPetsInList = 1;

            PetController petController = new PetController(mockPetRepo.Object);

            //dropdown list for owners (text =Full name of owner value = ID)
            string clientID = "002";

            string petType = "Dog";

       

            ViewResult result = petController.SearchForPets(clientID, petType) as ViewResult;

            List<Pet> resultModel = result.Model as List<Pet>;

            int actualNumOfPetsInList = resultModel.Count;
            // Assert

            Assert.Equal(expectedNumofPetsInList, actualNumOfPetsInList);



        }





        //helper methods

        public List<Pet> CreateMockPetData()
            {
            List<Pet> mockPets = new List<Pet>();
            string testClientid = "001";

            DateTime? petDOB = null;


            Pet pet = new Pet("Dogtest1","Dog","Male", petDOB, "Small", testClientid );
            mockPets.Add(pet);

            petDOB = new DateTime(2015, 11, 19);

            pet = new Pet("Cattest1", "Cat", "Male", petDOB, "Large", testClientid);
            mockPets.Add(pet);

            testClientid = "002";
            petDOB = new DateTime(2018, 10, 15);

            pet = new Pet("Dogtest2", "Dog", "Female", null, "Medium", testClientid);
            mockPets.Add(pet);

            pet = new Pet("Cattest2", "Cat", "Female", null, "Medium", testClientid);
            mockPets.Add(pet);


            return mockPets;
        }


    }
}
