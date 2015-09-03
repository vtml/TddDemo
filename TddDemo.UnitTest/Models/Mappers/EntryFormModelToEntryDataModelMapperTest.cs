using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;
using Ploeh.AutoFixture;
using TddDemo.Framework.Data;
using TddDemo.Framework.Models;
using TddDemo.Framework.Models.FormModels;
using TddDemo.Framework.Models.Mappers;

namespace TddDemo.Framework.UnitTest.Models.Mappers
{
    public class EntryFormModelToEntryDataModelMapperTest
    {
        private static readonly Fixture Fixture = new Fixture();
        
        [Test]
        public void Map_ShouldReturnAirportAsNull_WhenAirportCannotBeFound()
        {
            var airportRepo = Substitute.For<IRepository<IAirport>>();
            airportRepo.List.Returns(new List<IAirport>());

            var formModel = Fixture.Create<EntryFormModel>();
            var mapper = new EntryFormModelToEntryDataModelMapper(airportRepo);

            var dataModel = mapper.Map(formModel);

            Assert.IsNull(dataModel.Airport);
            Assert.AreEqual(formModel.FirstName, dataModel.FirstName);
            Assert.AreEqual(formModel.LastName, dataModel.LastName);
            Assert.AreEqual(formModel.NumberOfPets, dataModel.NumberOfPets);
        }

        [Test]
        public void Map_ShouldReturnAirport_WhenAirportExists()
        {
            var airportCode = Fixture.Create<string>();
            var airport = Fixture.Build<Airport>().With(x => x.AirportCode, airportCode).Create();

            var airportRepo = Substitute.For<IRepository<IAirport>>();
            airportRepo.List.Returns(new List<Airport> {airport});

            var formModel = Fixture.Build<EntryFormModel>().With(x => x.AirportCode, airportCode).Create();
            var mapper = new EntryFormModelToEntryDataModelMapper(airportRepo);

            var dataModel = mapper.Map(formModel);

            Assert.AreEqual(formModel.AirportCode, dataModel.Airport.AirportCode);
            Assert.AreEqual(formModel.FirstName, dataModel.FirstName);
            Assert.AreEqual(formModel.LastName, dataModel.LastName);
            Assert.AreEqual(formModel.NumberOfPets, dataModel.NumberOfPets);
        }
    }
}
