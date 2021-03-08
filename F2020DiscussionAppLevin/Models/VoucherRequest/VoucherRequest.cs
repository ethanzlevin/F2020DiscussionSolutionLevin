using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace F2020DiscussionAppLevin.Models
{
    public class VoucherRequest // when updating databse with new table/MVC class
                                // Add-migration (dont forget to add prop to AppDBContenxt)     Updata-database (classes ->tables)      Data population ( update dbinitializer - run app)
    {
        [Key]
        public int RequestID { get; set; }
        [Required]
        public DateTime RequestDate { get; set; }
        [Required]
        public string RequestStatus { get; set; }

        public DateTime? DecisionDate { get; set; }

        public double? RequestAmount { get; set; }

        public bool? VoucherRedeemed { get; set; }

        public string VoulenteerID { get; set; }
        [ForeignKey("VoulenteerID")]
        public Volunteer DecisionMaker { get; set; }

        [Required]
        public int PetID { get; set; }  //serves as FK in Realational databse

        //object oriented connection
        [ForeignKey("PetID")]
        public Pet RequestForPet { get; set; }


        public List<FundforVoucher> FundsforVoucherRequest { get; set; }





        public VoucherRequest()
        {

        }

        // when creating constructor with paramaters you need an empty constructor
        public VoucherRequest(string requestStatus, int petID)
        {
            this.RequestDate = DateTime.Today.Date;
            this.RequestStatus = requestStatus;
            this.PetID = petID;
            this.DecisionDate = null;
            this.RequestAmount = null;
            this.VoucherRedeemed = null;
            this.FundsforVoucherRequest = new List<FundforVoucher>();

        }
    }
}
