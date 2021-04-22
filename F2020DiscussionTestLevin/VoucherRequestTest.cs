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
    public class VoucherRequestTest
    {
        private Mock<IPetRepo> mockPetRepo;
        
        private VoucherRequestController voucherRequestController;
        private Mock<IVoucherRequestRepo> mockVoucherRequestRepo;
        private Mock<IApplicationUserRepo> mockApplicationUserRepo;
        private Mock<IClientRepo> mockClientRepo;
        private Mock<IVetClinicRepo> mockVetClinincRepo;
        public VoucherRequestTest()
        {
            mockPetRepo = new Mock<IPetRepo>();
            mockClientRepo = new Mock<IClientRepo>();
            mockVetClinincRepo = new Mock<IVetClinicRepo>();
            mockVoucherRequestRepo = new Mock<IVoucherRequestRepo>();
            mockApplicationUserRepo = new Mock<IApplicationUserRepo>();
            voucherRequestController = new VoucherRequestController(mockPetRepo.Object, mockVoucherRequestRepo.Object, mockApplicationUserRepo.Object, mockClientRepo.Object, mockVetClinincRepo.Object);


        }


        [Fact]
        public void ShouldDenyRequest()
        {
            int? voucherRequestID = 10;
            string requestDecision = "Denied";
            VoucherRequest voucherRequest = new VoucherRequest("Pending", 1);
            string userID = "1h24";
            
            mockVoucherRequestRepo.Setup(v => v.FindVoucherRequest(voucherRequestID))
                .Returns(voucherRequest);

            mockApplicationUserRepo.Setup(a => a.FindUserID()).Returns(userID);
            


            voucherRequestController.MakeVoucherRequestDecision(voucherRequestID, requestDecision);

            Assert.Equal(userID, voucherRequest.VoulenteerID);
            Assert.Equal(DateTime.Today.Date, voucherRequest.DecisionDate);
            Assert.Equal("Denied", voucherRequest.RequestStatus);


        }


        [Fact]
        public void ShouldApproveRequest()
        {
            int? voucherRequestID = 11;
            string requestDecision = "Approved";
            string userID = "1h24";
            VoucherRequest voucherRequest = new VoucherRequest("Pending", 2);
            Pet pet = new Pet("test", "Dog", "Male", null, "Large", "001");

            mockApplicationUserRepo.Setup(a => a.FindUserID()).Returns(userID);

            mockVoucherRequestRepo.Setup(v => v.FindVoucherRequest(voucherRequestID))
                .Returns(voucherRequest);

            double requestAmountForPet = 120.00;
            double calculatedRequestAmount = 120.00;

            mockPetRepo.Setup(m => m.FindRequestAmount(2)).Returns(calculatedRequestAmount);


            voucherRequestController.MakeVoucherRequestDecision(voucherRequestID, requestDecision);

            Assert.Equal(userID, voucherRequest.VoulenteerID);

            Assert.Equal(DateTime.Today.Date, voucherRequest.DecisionDate);
            Assert.Equal("Approved", voucherRequest.RequestStatus);
            Assert.Equal(requestAmountForPet, voucherRequest.RequestAmount);
            
        }









    }
}
