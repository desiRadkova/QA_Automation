using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnit_GitHub_API_Tests.DataModels
{
    public class Place
    {
        [JsonProperty("place name")]
        public string PlaceName { get; set; }
        [JsonProperty("state")]
        public string State { get; set; }
    }
}
