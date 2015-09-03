using Newtonsoft.Json;

namespace TddDemo.Framework.Models.DTO
{
    public class EntrySubmissionDto
    {
        /*
         {
            "EntrySubmission": {
                "Name": "",
                "NoOfPets": 3,
                "ClosestAirport": {
                    "ThreeLetterCode": "MEL",
                    "Airport": "Melbourne Tullamarine"
                }
            }
        }
        */
        
        [JsonProperty("Name")]
        public string FullName { get; set; }

        [JsonProperty("NoOfPets")]
        public int NumberOfPets { get; set; }

        [JsonProperty("ClosestAirport")]
        public AirportDto Airport { get; set; }
    }
}
