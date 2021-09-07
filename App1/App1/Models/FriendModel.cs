using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace App1.Models
{
    public class FriendModel 
    {
        [PrimaryKey, AutoIncrement]
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set;}
        [JsonProperty("number")]
        public string Number { get; set; }
        [JsonProperty("address")]
        public string Address { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("sortname")]
        private string sortName;
        public string SortName 
        {
            get => sortName;
            set
            {              
                sortName = Name.Substring(0,1);
            }

        }
        


    }
}
