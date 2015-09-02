using System;
using TddDemo.Framework.Data;

namespace TddDemo.Framework.Models.DataModels
{
    public class EntryDataModel : IEntity
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual IAirport Airport { get; set; }
        public int NumberOfPets { get; set; }
    }
}
