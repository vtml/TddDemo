using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using NUnit.Framework;
using Ploeh.AutoFixture;
using TddDemo.Framework.Models.FormModels;

namespace TddDemo.Framework.UnitTest.Models.FormModels
{
    public class EntryFormModelTest
    {
        private static readonly Fixture Fixture = new Fixture();
        
        private static object[] VariousFormModels()
        {
            var validAirportCode = Fixture.Create<string>().Substring(0, 3);
            var validFormModel = Fixture.Build<EntryFormModel>().With(x => x.AirportCode, validAirportCode).With(x => x.NumberOfPets, new Generator<int>(Fixture).First(pt => pt > 0 && pt < 100)).Create();
            var noFirstName = Fixture.Build<EntryFormModel>().With(x => x.AirportCode, validAirportCode).Without(x => x.FirstName).Create();
            var noLastName = Fixture.Build<EntryFormModel>().With(x => x.AirportCode, validAirportCode).Without(x => x.LastName).Create();
            var lotsOfPets = Fixture.Build<EntryFormModel>().With(x => x.AirportCode, validAirportCode).With(x => x.NumberOfPets, new Generator<int>(Fixture).First(pt => pt >  100 && pt <  500)).Create();
            var list = new object[]
                    {
                        new object[] {validFormModel, true},
                        new object[] {noFirstName, false},
                        new object[] {noLastName, false},
                        new object[] {lotsOfPets, false},
                    };
            return list;    
        }

        [Test, TestCaseSource("VariousFormModels")]
        public void EntryFormModel_DataAnnotationTest(EntryFormModel model, bool isValid)
        {
            var validationResultsList = new List<ValidationResult>();
            var validationContext = new ValidationContext(model, null, null);
            var validaitonResult = Validator.TryValidateObject(model, validationContext, validationResultsList, true);

            Assert.AreEqual(isValid, validaitonResult);
            Assert.AreEqual(isValid, !validationResultsList.Any());
        }
    }
}
