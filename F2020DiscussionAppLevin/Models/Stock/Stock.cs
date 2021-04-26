using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace F2020DiscussionAppLevin.Models
{
    public class Stock
    {
        [Key]
        public int StockID { get; set; }

        [JsonProperty(PropertyName = "ACT Symbol")]
        public string StockSymbol { get; set; }

        [JsonProperty(PropertyName = "Company Name")]
        public string StockName { get; set; }

        public Stock(string symbol, string name)
        {
            this.StockSymbol = symbol;
            this.StockName = name;
        }

        public Stock() { }
    }
}
