using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CurrencyAPITestMAUI
{
    internal class CurrencyResponseModel
    {
        public string date { get; set; }
        public string historical { get; set; }
        public Info info { get; set; }
        public Query query { get; set; }
        public double result { get; set; }
        public bool success { get; set; }
        public Dictionary<string, string>? symbols { get; set; }

    }

    public class Query
    {
        public int amount { get; set; }
        public string from { get; set; }
        public string to { get; set; }
    }

    public class Info
    {

        public double rate { get; set; }
        public int timestamp { get; set; }
    }


}
