using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace F2020DiscussionAppLevin.Models
{
    public class Volunteer : ApplicationUser
    {
        public int NumberofHoursWorked { get; set; }


        public Volunteer(string firstname, string lastname, string address, string phonenumber, string email, string password, int numberofhoursvolunteered) :
            base(firstname, lastname, address, phonenumber, email, password)
        {
            this.NumberofHoursWorked = numberofhoursvolunteered;
        }

        public Volunteer()
        {

        }
    }
}
