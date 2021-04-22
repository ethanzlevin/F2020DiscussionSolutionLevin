using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace F2020DiscussionAppLevin.Models
{
    public class DistanceViewModel
    {
        public int VetClinicID { get; set; }
        public string VetClinicName { get; set; }
        public string VetClinicAddress { get; set; }
        public double DistanceInMiles { get; set; }
        public int DurationInMinutes { get; set; }
    }
}
