using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace App2.Models
{
    class user
    {
        [JsonProperty("email")]
        public string UserName { get; set; }
        [JsonProperty("password")]       
        public string Password { get; set; }
        
        public bool CheckInformation()
        {
            if (string.IsNullOrEmpty(UserName) && string.IsNullOrEmpty(Password))
                return true;
            else
                return false;

        }
    }
}
