using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace F2020DiscussionAppLevin.Models
{
    public class Pet
    {
        //attribute
        // private int petID;

        //property

        [Key]
        public int PetID { get; set; }

        public string PetName { get; set; }
        [Required(ErrorMessage = "Pet Type should be Cat or Dog")]
        public string PetType { get; set; }
        [Required]
        public String PetGender { get; set; }

        public DateTime? PetDOB { get; set; }  //? = accept null


        //db connection
        [Required]
        public string ClientID { get; set; }
        [ForeignKey("ClientID")]
        //object oriented connection
        public Client Client { get; set; }


        public string PetSize { get; set; } // updated in vs 15

        public List<VoucherRequest> VoucherRequestForPet { get; set; } //basically acts as foreign key/connection in obj oriented without using a fk 
        //fk is in VR because of 1-* relationship in db

        public Pet(){ }

        public Pet(string petname, string petType, string petGender, DateTime? petDOB, string petSize, string clientID)
        {
            this.PetName = petname;
            this.PetType = petType;
            this.PetGender = petGender;
            this.PetDOB = petDOB;
            this.PetSize = petSize;
            this.ClientID = clientID;
            this.VoucherRequestForPet = new List<VoucherRequest>();
        }


    }

}
