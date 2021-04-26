using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using F2020DiscussionAppLevin.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace F2020DiscussionAppLevin.Controllers
{
    public class StockController : Controller
    {
        private IStockRepo iStockRepo;
        public StockController(IStockRepo stockRepo)
        {
            this.iStockRepo = stockRepo;
        }

        public void ReadAndSaveStocks()
        {
            string filePath = Directory.GetCurrentDirectory() + "/data/nyse_listed_stocks_json.json";
            var StockDataInJson = System.IO.File.ReadAllText(filePath);
            //Class object -> Json(serialization)
            //Json -> Class Object (deserialization)

            List<Stock> stocks = JsonConvert.DeserializeObject<List<Stock>>(StockDataInJson);

            iStockRepo.AddStocks(stocks);
        }

        public string GetStockDataInJson(string term) //JQuery method autocomplete - string must be called term
        {
            var result = (from s in iStockRepo.ListAllStocks()
                          where s.StockName.StartsWith(term, StringComparison.OrdinalIgnoreCase)
                          select new { s.StockSymbol, s.StockName }).ToList();
            return JsonConvert.SerializeObject(result);

            
        }

        public IActionResult GetStockInformation()
        {
            return View();
        }

        public IActionResult GetStockInformationResult(string selectedStock)
        {
            return View("GetStockInformation", selectedStock);
        }
    }
}
