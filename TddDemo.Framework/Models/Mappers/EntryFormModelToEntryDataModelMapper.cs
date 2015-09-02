using System;
using System.Linq;
using TddDemo.Framework.Data;
using TddDemo.Framework.Models.DataModels;
using TddDemo.Framework.Models.FormModels;

namespace TddDemo.Framework.Models.Mappers
{
    public class EntryFormModelToEntryDataModelMapper : IMapper<EntryFormModel, EntryDataModel>
    {
        private readonly IRepository<IAirport> _airportRepository;

        public EntryFormModelToEntryDataModelMapper(IRepository<IAirport> airportRepository)
        {
            _airportRepository = airportRepository;
        }

        public EntryDataModel Map(EntryFormModel source)
        {
            var airport = _airportRepository.List.FirstOrDefault(x => x.AirportCode.Equals(source.AirportCode, StringComparison.InvariantCultureIgnoreCase));
            var target = new EntryDataModel
            {
                FirstName = source.FirstName,
                LastName = source.LastName,
                NumberOfPets = source.NumberOfPets
            };

            if (airport != null)
            {
                target.Airport = airport;
            }
            return target;
        }
    }
}
