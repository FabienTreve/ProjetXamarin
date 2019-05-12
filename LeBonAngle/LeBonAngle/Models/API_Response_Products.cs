using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeBonAngle.Models
{
    public class API_Response_Products
    {
        [JsonProperty("success")]
        public string Success { get; set; }

        [JsonProperty("products")]
        public List<Product> Products { get; set; }
    }
}
