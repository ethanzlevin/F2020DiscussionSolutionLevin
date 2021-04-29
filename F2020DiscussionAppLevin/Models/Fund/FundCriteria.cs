using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace F2020DiscussionAppLevin.Models
{
    public class FundCriteria
    {
        public string ClientLocation { get; set; } //counties
         [Key]
        public int FundCriteriaID { get; set; }

        public string PetGender { get; set; }

        public string PetSize { get; set; }

        public string PetType { get; set; }

        public int FundID { get; set; }
        [ForeignKey("FundID")]
        public Fund Fund { get; set; }

        public FundCriteria(int fundID, string clientLocation = null, string petType = null, string petGender = null, string petSize = null)
        {
           
            this.FundID = fundID;

            this.PetType = petType;
            this.PetGender = petGender;
            this.PetSize = petSize;
            this.ClientLocation = clientLocation;


        }
        public FundCriteria()
        {

        }


    }
}
