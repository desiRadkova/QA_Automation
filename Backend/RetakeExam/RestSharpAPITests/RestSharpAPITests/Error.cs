using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RestSharpAPITests
{
    public  class Error
    {
        [JsonPropertyName("errMsg")]
        public string errMsg { get; set; } 
    }
}
