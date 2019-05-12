using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeBonAngle.Models
{
    public class API_Response_User
    {
        [JsonProperty("success")]
        public string Success { get; set; }

        [JsonProperty("user")]
        public User User { get; set; }
    }
}
