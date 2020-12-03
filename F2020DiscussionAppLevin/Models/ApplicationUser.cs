using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace F2020DiscussionAppLevin.Models
{
    public class ApplicationUser : IdentityUser
    {
        //primary key is id it preexists dont created an ID prop
        //ID is a string

        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Address { get; set; }

        public string Fullname 
        {
            get
            { return (FirstName + " " + LastName); }
        }

        public ApplicationUser(string firstname, string lastname, string address, string phonenumber, string email, string password)
        {
            this.FirstName = firstname;
            this.LastName = lastname;
            this.Address = address;
            this.PhoneNumber = phonenumber;
            this.Email = email;
            this.UserName = email;
            PasswordHasher<ApplicationUser> passwordHasher = new PasswordHasher<ApplicationUser>();
            this.PasswordHash = passwordHasher.HashPassword(this, password);
            this.SecurityStamp = Guid.NewGuid().ToString();
        }

        public ApplicationUser() { }

    }
}
