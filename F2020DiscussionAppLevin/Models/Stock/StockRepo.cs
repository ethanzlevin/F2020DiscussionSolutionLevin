using F2020DiscussionAppLevin.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace F2020DiscussionAppLevin.Models
{
    public class StockRepo : IStockRepo
    {
        private ApplicationDbContext database;

        //Dependency Injection
        public StockRepo(ApplicationDbContext dbContext)
        {
            this.database = dbContext;
        }
        public void AddStocks(List<Stock> stocks)
        {
            if (!database.Stock.Any())
            {
                database.Stock.AddRange(stocks);
                database.SaveChanges();
            }
        }

        public List<Stock> ListAllStocks()
        {
            List<Stock> allStocks = database.Stock.ToList<Stock>();
            return allStocks;
        }
    }
}
