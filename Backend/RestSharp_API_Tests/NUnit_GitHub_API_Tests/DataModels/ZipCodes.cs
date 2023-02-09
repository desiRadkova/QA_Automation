using Newtonsoft.Json;
using System.Text.Json.Serialization;
using System.Xml.Linq;

namespace NUnit_GitHub_API_Tests.DataModels
{
    //public class RootObject
    //{
    //    public List<Countries> GetCountriesRestResult { get; set; }
    //}
    public class ZipCodes
    {
        [JsonPropertyName("country")]
        public string Country { get; set; }
        [JsonProperty("post code")]
        public string PostCode { get; set; }
        [JsonProperty("country abbreviation")]
        public string CountryAbbreviation { get; set; }
        [JsonProperty("places")]
        public List<Place> Places { get; set; }

        public int population { get; set; }

    }
}