using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace F2020DiscussionAppLevin.Models
{
    public class Client : ApplicationUser
    {

        public List<Pet> ClientPets { get; set; }


        public Client(string firstname, string lastname, string address, string phonenumber, string email, string password) :
            base(firstname, lastname, address, phonenumber, email, password)  
        {
            this.ClientPets = new List<Pet>();
        }

        public Client()
        {

        }
    }
}
