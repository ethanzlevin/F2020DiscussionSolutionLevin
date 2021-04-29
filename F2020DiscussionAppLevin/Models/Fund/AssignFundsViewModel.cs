using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace F2020DiscussionAppLevin.Models
{
    public class AssignFundsViewModel
    {
        public List<Fund> FundList { get; set; }
        public List<VoucherRequest> VoucherRequestList { get; set; }

        public int FundID { get; set; }
        public int VoucherRequestID { get; set; }
        public int AmountAssigned { get; set; }
    }
}
