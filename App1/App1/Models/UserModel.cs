using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace App1.Models
{
    public class UserModel
    {
        [PrimaryKey, AutoIncrement]
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("password")]
        public string Password { get; set; }
        [JsonProperty("repassword")]
        public string RePassword { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("number")]
        public string Number { get; set; }
        [JsonProperty("address")]
        public string Address { get; set; }
        [JsonProperty("contact")]
        public string Contact { get; set; }
    }
}
