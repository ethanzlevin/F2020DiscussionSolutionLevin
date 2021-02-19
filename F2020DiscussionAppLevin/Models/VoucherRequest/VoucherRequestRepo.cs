using F2020DiscussionAppLevin.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace F2020DiscussionAppLevin.Models
{
    public class VoucherRequestRepo : IVoucherRequestRepo
    {
        private ApplicationDbContext database;


        // dependancy injection
        public VoucherRequestRepo(ApplicationDbContext dbContext)
        {
            this.database = dbContext;
        }

        public void AddVoucherRequest(VoucherRequest voucherRequest)
        {
            database.VoucherRequest.Add(voucherRequest);
            database.SaveChanges();
        }
    }
}
