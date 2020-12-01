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

        //helper methods

        public List<Pet> CreateMockPetData()
            {
            List<Pet> mockPets = new List<Pet>();
            string testClientid = "001";

            Pet pet = new Pet("Dogtest1","Dog","Male", null, "Small", testClientid );
            mockPets.Add(pet);

            new Pet("Cattest1", "Cat", "Male", null, "Large", testClientid);
            mockPets.Add(pet);

            new Pet("Dogtest2", "Dog", "Female", null, "Medium", testClientid);
            mockPets.Add(pet);

            return mockPets;
        }


    }
}
