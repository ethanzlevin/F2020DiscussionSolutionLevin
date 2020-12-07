using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace F2020DiscussionAppLevin.Models
{
    public class SearchForPetsViewModel
    {
        public string ClientID { get; set; }

        public string PetType { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }
    }
}
