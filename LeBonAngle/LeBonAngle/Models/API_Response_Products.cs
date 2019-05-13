using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ListingOgGang.Models
{
    public class API_Response_Products
    {
        [JsonProperty("success")]
        public string Success { get; set; }

        [JsonProperty("posts")]
        public List<Post> Posts { get; set; }
    }
}
