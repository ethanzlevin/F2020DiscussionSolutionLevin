using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace F2020DiscussionAppLevin.Models
{
    public class Fund
    {
        [Key]
        public int FundID { get; set; }
        [Required]
        public string FundName { get; set; }
        [Required]
        public double CurrentFundAmount { get; set; }
        [Required]
        public string FundType { get; set; }
        [Required]
        public double OriginalFundAmount { get; set; }

        public int? FundCriteriaID { get; set; }

        //object oriented
        public List<FundforVoucher> RequestsForFund {get;set;}

        [ForeignKey("FundCriteriaID")]
        public FundCriteria FundCriteria { get; set; }

        public Fund() { }




        public Fund(string fundName, string fundType, double originalFundAmount )
        {
            this.FundName = fundName;
            this.CurrentFundAmount = originalFundAmount;
            this.FundType = fundType;
            this.OriginalFundAmount = originalFundAmount;
            this.RequestsForFund = new List<FundforVoucher>();
            this.FundCriteriaID = null;


        }

    }
}
