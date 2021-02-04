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
        private Mock<IClientRepo> mockClientRepo;
        [Fact]
        public void ShouldListAllPets()
        {
            //AA

            //1.Arrange
            //ApplicationDbContext database = null; controller does not use databse for testing
            
            mockPetRepo = new Mock<IPetRepo>();
            mockClientRepo = new Mock<IClientRepo>();

            List<Pet> mockPets = CreateMockPetData();
            mockPetRepo.Setup(m => m.ListAllPets()).Returns(mockPets);

            int expectedNumofPetsInList = 4;

            PetController petController = new PetController(mockPetRepo.Object, mockClientRepo.Object);
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
            mockClientRepo = new Mock<IClientRepo>();

            List<Pet> mockPets = CreateMockPetData();
            mockPetRepo.Setup(m => m.ListAllPets()).Returns(mockPets); //logic in controller method
            mockClientRepo.Setup(m => m.ListAllClients()).Returns(new List<Client>());

            int expectedNumofPetsInList = 2;

            PetController petController = new PetController(mockPetRepo.Object, mockClientRepo.Object);

            //dropdown list for owners (text =Full name of owner value = ID)
            string clientID = "001";
            

            SearchForPetsViewModel viewModel = new SearchForPetsViewModel();
            viewModel.ClientID = clientID;
            viewModel.FirstVisit = "No";
            

            //act

            ViewResult result = petController.SearchForPets(viewModel) as ViewResult;

            SearchForPetsViewModel resultModel = result.Model as SearchForPetsViewModel;

            int actualNumOfPetsInList = resultModel.ResultPetList.Count;
            // Assert

            Assert.Equal(expectedNumofPetsInList, actualNumOfPetsInList);



        }

        [Fact]
        public void ShouldSearchForPetsByOwnerandPetType()
        {
            //arange
            mockPetRepo = new Mock<IPetRepo>();
            mockClientRepo = new Mock<IClientRepo>();

            List<Pet> mockPets = CreateMockPetData();
            mockPetRepo.Setup(m => m.ListAllPets()).Returns(mockPets); //logic in controller method
            mockClientRepo.Setup(m => m.ListAllClients()).Returns(new List<Client>());

            int expectedNumofPetsInList = 1;

            PetController petController = new PetController(mockPetRepo.Object, mockClientRepo.Object);

            //dropdown list for owners (text =Full name of owner value = ID)
            string clientID = "002";

            string petType = "Dog";

            SearchForPetsViewModel viewModel = new SearchForPetsViewModel();
            viewModel.ClientID = clientID;
            viewModel.PetType = petType;
            viewModel.FirstVisit = "No";

            ViewResult result = petController.SearchForPets(viewModel) as ViewResult;

            SearchForPetsViewModel resultModel = result.Model as SearchForPetsViewModel;

            int actualNumOfPetsInList = resultModel.ResultPetList.Count;
            // Assert

            Assert.Equal(expectedNumofPetsInList, actualNumOfPetsInList);



        }



        [Fact]
        public void ShouldSearchForPetsByARangeOfDecisionDates()
        {
            //arange
            mockPetRepo = new Mock<IPetRepo>();
            mockClientRepo = new Mock<IClientRepo>();

            List<Pet> mockPets = CreateMockPetData();
            mockPetRepo.Setup(m => m.ListAllPets()).Returns(mockPets); //logic in controller method
            
            mockClientRepo.Setup(m => m.ListAllClients()).Returns(new List<Client>());

            int expectedNumofPetsInList = 3;

            PetController petController = new PetController(mockPetRepo.Object, mockClientRepo.Object);

            //dropdown list for owners (text =Full name of owner value = ID)
            DateTime? startDate = new DateTime(2020, 10, 1);
            DateTime? endDate = new DateTime(2020, 10, 31);

            SearchForPetsViewModel viewModel = new SearchForPetsViewModel();
            viewModel.StartDate = startDate;
            viewModel.EndDate = endDate;
            viewModel.FirstVisit = "No";

            ViewResult result = petController.SearchForPets(viewModel) as ViewResult;

            SearchForPetsViewModel resultModel = result.Model as SearchForPetsViewModel;

            int actualNumOfPetsInList = resultModel.ResultPetList.Count;
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
            pet.PetID = 1;
            

            VoucherRequest voucherRequest = new VoucherRequest("Denied", 1);
            voucherRequest.DecisionDate = new DateTime(2020, 10, 1);
            pet.VoucherRequestForPet.Add(voucherRequest);
            voucherRequest.RequestForPet = pet;

            voucherRequest = new VoucherRequest("Pending", 1);
            pet.VoucherRequestForPet.Add(voucherRequest);
            voucherRequest.RequestForPet = pet;

            mockPets.Add(pet);

            petDOB = new DateTime(2015, 11, 19);

            pet = new Pet("Cattest1", "Cat", "Male", petDOB, "Large", testClientid);
            pet.PetID = 2;

            voucherRequest = new VoucherRequest("Approved", 2);
            voucherRequest.DecisionDate = new DateTime(2020, 10, 15);
            pet.VoucherRequestForPet.Add(voucherRequest);
            voucherRequest.RequestForPet = pet;

            voucherRequest = new VoucherRequest("Denied", 2);
            voucherRequest.DecisionDate = new DateTime(2020, 11, 10);
            pet.VoucherRequestForPet.Add(voucherRequest);
            voucherRequest.RequestForPet = pet;




            mockPets.Add(pet);

            testClientid = "002";
            petDOB = new DateTime(2018, 10, 15);

            pet = new Pet("Dogtest2", "Dog", "Female", null, "Medium", testClientid);
            pet.PetID = 3;
            voucherRequest = new VoucherRequest("Denied", 3);
            voucherRequest.DecisionDate = new DateTime(2020, 10, 25);
            pet.VoucherRequestForPet.Add(voucherRequest);
            voucherRequest.RequestForPet = pet;
            mockPets.Add(pet);


            pet = new Pet("Cattest2", "Cat", "Female", null, "Medium", testClientid);
            pet.PetID = 4;
            voucherRequest = new VoucherRequest("Approved", 4);
            voucherRequest.DecisionDate = new DateTime(2020, 11, 1);
            pet.VoucherRequestForPet.Add(voucherRequest);
            voucherRequest.RequestForPet = pet;
            mockPets.Add(pet);


            return mockPets;
        }


    }
}
