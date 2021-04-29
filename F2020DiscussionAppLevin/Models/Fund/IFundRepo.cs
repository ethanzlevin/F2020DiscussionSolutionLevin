using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace F2020DiscussionAppLevin.Models
{
    public interface IFundRepo
    {
        List<Fund> ListAllFunds();
        Fund FindFund(int fundID);
        void AddFundForVoucher(FundForVoucher fundForVoucher);
        void UpdateFund(Fund fund);
    }
}
