using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace F2020DiscussionAppLevin.Models
{
    public class VetClinic
    {
        [Key]
        public int VetClinicID { get; set; }
        public string VetClinicName { get; set; }
        public string VetClinicAddress { get; set; }

        public VetClinic(string clinicName, string clinicAddress)
        {
            this.VetClinicName = clinicName;
            this.VetClinicAddress = clinicAddress;
        }

        public VetClinic() { }
    }
}
