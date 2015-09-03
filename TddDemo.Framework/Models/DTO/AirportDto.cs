using Newtonsoft.Json;

namespace TddDemo.Framework.Models.DTO
{
    public class AirportDto
    {
        [JsonProperty("ThreeLetterCode")]
        public string AirportCode { get; set; }

        [JsonProperty("Airport")]
        public string AirportName { get; set; }
    }
}
