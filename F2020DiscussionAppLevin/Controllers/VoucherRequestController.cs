using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using F2020DiscussionAppLevin.Models;
using Microsoft.AspNetCore.Mvc;

namespace F2020DiscussionAppLevin.Controllers
{
    public class VoucherRequestController : Controller
    {

        private IPetRepo iPetRepo;
        
        private IVoucherRequestRepo ivoucherRequestRepo;

        private IApplicationUserRepo iApplicationUserRepo;

        private IClientRepo iClientRepo;

        private IVetClinicRepo iVetClinicRepo;


        // dependancy injection
        public VoucherRequestController(IPetRepo petRepo, IVoucherRequestRepo voucherRequestRepo, IApplicationUserRepo applicationUserRepo, IClientRepo clientRepo, IVetClinicRepo vetClinicRepo)
        {
            this.iPetRepo = petRepo;
            this.iVetClinicRepo = vetClinicRepo;
            this.ivoucherRequestRepo = voucherRequestRepo;
            this.iApplicationUserRepo = applicationUserRepo;
            this.iClientRepo = clientRepo;
            
        }

        public IActionResult MakeVoucherRequestDecision(int? voucherRequestID, string requestDecision)
        {
            VoucherRequest voucherRequest = ivoucherRequestRepo.FindVoucherRequest(voucherRequestID);

            voucherRequest.RequestStatus = requestDecision;
            voucherRequest.DecisionDate = DateTime.Today.Date;
            voucherRequest.VoulenteerID = iApplicationUserRepo.FindUserID();

            if (requestDecision == "Approved")
            {
               voucherRequest.RequestAmount = iPetRepo.FindRequestAmount(voucherRequest.PetID);
                Client client = iClientRepo.FindClient(voucherRequest.RequestForPet.ClientID);
                string clientAddress = client.Address;
                VetClinicController vetClinicController = new VetClinicController(iVetClinicRepo, iApplicationUserRepo, iClientRepo);

                

                voucherRequest.VetClinicID = vetClinicController.FindNearestVetClinic(clientAddress);
            }
            ivoucherRequestRepo.MakeRequestDecision(voucherRequest);

            return RedirectToAction("ListAllPets", "Pet");
        }

      
    }
}
