using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeBonAngle.Models
{
    public class API_Response_Authenticate
    {
        [JsonProperty("success")]
        public string Success { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; }
    }
}
