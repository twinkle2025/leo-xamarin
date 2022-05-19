using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Leo.Models.APITemplate
{
    class APIResponse
    {
        [JsonProperty("status")]
        public int Status { get; set; }
        [JsonProperty("error")]
        public string Error { get; set; }
    }

    public class LoginSuccess
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("username")]
        public int UserName{ get; set; }
        [JsonProperty("token")]
        public string Token { get; set; }

    }
}
