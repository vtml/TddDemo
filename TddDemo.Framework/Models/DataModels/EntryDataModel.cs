using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TddDemo.Framework.Models.DataModels
{
    public class EntryDataModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Airport Airport { get; set; }

        public int NumberOfPets { get; set; }
    }
}
