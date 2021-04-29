using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using F2020DiscussionAppLevin.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace F2020DiscussionAppLevin.Controllers
{
    public class FundForVoucherController : Controller
    {
        private IFundRepo iFundRepo;
        private IVoucherRequestRepo iVoucherRequestRepo;

        public FundForVoucherController(IFundRepo fundRepo, IVoucherRequestRepo voucherRequestRepo)
        {
            this.iFundRepo = fundRepo;
            this.iVoucherRequestRepo = voucherRequestRepo;
        }
        public void CreateDDLs()
        {
            ViewData["AllFunds"] = new SelectList(iFundRepo.ListAllFunds(), "FundID", "FundName");

            var selectListItems = from VR in iVoucherRequestRepo.ListAllApprovedVoucherRequests()
                                  select new
                                  {
                                      RequestID = VR.RequestID,
                                      ReqPetClient = VR.RequestID + ", " + VR.PetID + ", " + VR.RequestForPet.Client.Fullname
                                  };
            ViewData["AllVoucherRequests"] = new SelectList(selectListItems, "RequestID", "ReqPetClient");
        }

        [HttpGet]
        public IActionResult AssignFundsForVoucher()
        {
            CreateDDLs();
            AssignFundsViewModel viewModel = new AssignFundsViewModel();
            viewModel.FundList = iFundRepo.ListAllFunds();
            viewModel.VoucherRequestList = iVoucherRequestRepo.ListAllApprovedVoucherRequests();
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult AssignFundsForVoucher(AssignFundsViewModel viewModel)
        {
            Fund fund = iFundRepo.FindFund(viewModel.FundID);
            if (fund.CurrentFundAmount >= viewModel.AmountAssigned)
            {
                FundForVoucher fundForVoucher = new FundForVoucher(viewModel.VoucherRequestID, viewModel.FundID, viewModel.AmountAssigned);
                iFundRepo.AddFundForVoucher(fundForVoucher);
                fund.CurrentFundAmount -= viewModel.AmountAssigned;
                iFundRepo.UpdateFund(fund);

                return RedirectToAction("AssignFundsForVoucher");
            }
            else {
                ModelState.AddModelError("InsufficientFunds", "Insufficient Funds for assignment");
                CreateDDLs();
                viewModel.FundList = iFundRepo.ListAllFunds();
                viewModel.VoucherRequestList = iVoucherRequestRepo.ListAllApprovedVoucherRequests();
                return View(viewModel); }
            
        }

    }
}
