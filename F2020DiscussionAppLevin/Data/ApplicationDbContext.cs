using System;
using System.Collections.Generic;
using System.Text;
using F2020DiscussionAppLevin.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace F2020DiscussionAppLevin.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Pet> Pet { get; set; }

        public DbSet<VoucherRequest> VoucherRequest { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
