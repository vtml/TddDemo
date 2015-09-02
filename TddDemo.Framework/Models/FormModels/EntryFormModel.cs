using System.ComponentModel.DataAnnotations;

namespace TddDemo.Framework.Models.FormModels
{
    public class EntryFormModel
    {
        [Required]
        [MinLength(1)]
        [MaxLength(100)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(100)]
        public string LastName { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(3)]
        public string AirportCode { get; set; }

        [Range(0, 100)]
        public int NumberOfPets { get; set; }
    }
}
