using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeBonAngle.Models
{
    public class API_Response_Category
    {
        [JsonProperty("success")]
        public string Success { get; set; }

        [JsonProperty("categories")]
        public List<Category> Categories { get; set; }
    }
}
