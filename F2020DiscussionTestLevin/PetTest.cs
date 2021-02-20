using System;
using Xunit;
using F2020DiscussionAppLevin.Controllers;
using F2020DiscussionAppLevin.Data;
using Moq;
using F2020DiscussionAppLevin.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace F2020DiscussionTestLevin
{
    public class PetTest
    {
        
        //instance variable 
        private Mock<IPetRepo> mockPetRepo;
        private Mock<IClientRepo> mockClientRepo;
        private PetController petController;
        private Mock<IVoucherRequestRepo> mockVoucherRequestRepo;
        public PetTest()
        {
            mockPetRepo = new Mock<IPetRepo>();
            mockClientRepo = new Mock<IClientRepo>();
            mockVoucherRequestRepo = new Mock<IVoucherRequestRepo>();
            petController = new PetController(mockPetRepo.Object, mockClientRepo.Object, mockVoucherRequestRepo.Object);

            
        }

        [Fact]
        public void ShouldEditPet()
        {
            Pet pet = new Pet("testName", "testType", "testGender", new DateTime(2021, 01, 01), "testsize", "001");
            pet.PetID = 5;
            mockPetRepo.Setup(m => m.EditPet(It.IsAny<Pet>()));

            petController.EditPet(pet);


            mockPetRepo.Verify(m => m.EditPet(pet), Times.Exactly(1));

        }


        [Fact]
        public void ShouldListAllPets()
        {
            //AA

            //1.Arrange
            //ApplicationDbContext database = null; controller does not use databse for testing
            
            

            List<Pet> mockPets = CreateMockPetData();
            mockPetRepo.Setup(m => m.ListAllPets()).Returns(mockPets);

            int expectedNumofPetsInList = 4;

            
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
            

            List<Pet> mockPets = CreateMockPetData();
            mockPetRepo.Setup(m => m.ListAllPets()).Returns(mockPets); //logic in controller method
            mockClientRepo.Setup(m => m.ListAllClients()).Returns(new List<Client>());

            int expectedNumofPetsInList = 2;


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
          
            List<Pet> mockPets = CreateMockPetData();
            mockPetRepo.Setup(m => m.ListAllPets()).Returns(mockPets); //logic in controller method
            mockClientRepo.Setup(m => m.ListAllClients()).Returns(new List<Client>());

            int expectedNumofPetsInList = 1;


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

            List<Pet> mockPets = CreateMockPetData();
            mockPetRepo.Setup(m => m.ListAllPets()).Returns(mockPets); //logic in controller method
            
            mockClientRepo.Setup(m => m.ListAllClients()).Returns(new List<Client>());

            int expectedNumofPetsInList = 3;


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

        [Fact]
        public void ShouldNotAddNewPet() //sad path
        {
            Pet pet = new Pet();
            string expectedErrorMessage = "Pet Type should be Cat or Dog";
            var validationResult = new List<ValidationResult>();
            

            bool isValid = Validator.TryValidateObject(pet, new ValidationContext(pet), validationResult);


            Assert.False(isValid);
            string actualErrorMessage = validationResult[0].ToString();
            Assert.Equal(expectedErrorMessage, actualErrorMessage);

        }
        [Fact]
        public void ShouldAddNewPet() //happy path
        {
            Pet pet = new Pet("testName", "testType", "testGender", new DateTime(2021, 01, 01), "testsize", "001");
            pet.PetID = 5;
            mockPetRepo.Setup(m => m.AddPet(pet)).Returns(pet.PetID); //need this explained ask jaren


            VoucherRequest voucherRequest = null;
            //fluent notation--ItIsAnyVoucherRequest
            mockVoucherRequestRepo.Setup(v => v.AddVoucherRequest(It.IsAny<VoucherRequest>()))
                .Callback<VoucherRequest>(vr => voucherRequest = vr);

            

            petController.AddPet(pet);


            mockPetRepo.Verify(m => m.AddPet(pet), Times.Exactly(1));
            Assert.Equal("Pending", voucherRequest.RequestStatus);
            Assert.Equal(DateTime.Today.Date, voucherRequest.RequestDate);

        }


    }
}
