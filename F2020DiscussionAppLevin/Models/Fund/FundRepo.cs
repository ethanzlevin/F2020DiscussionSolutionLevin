using F2020DiscussionAppLevin.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace F2020DiscussionAppLevin.Models
{
    public class FundRepo : IFundRepo
    {
        private ApplicationDbContext database;

        public FundRepo(ApplicationDbContext dbContext)
        {
            this.database = dbContext;
        }

        public void AddFundForVoucher(FundForVoucher fundForVoucher)
        {
            database.FundForVoucher.Add(fundForVoucher);
            database.SaveChanges();
        }

        public Fund FindFund(int fundID)
        {
            return database.Fund.Find(fundID);
        }

        public List<Fund> ListAllFunds()
        {
            return database.Fund.Include(f => f.FundCriteria).Include(f => f.RequestsForFund).ToList();
        }

        public void UpdateFund(Fund fund)
        {
            database.Fund.Update(fund);
            database.SaveChanges();
        }
    }
}
