using Newtonsoft.Json;
using NUnit.Framework;
using Ploeh.AutoFixture;
using TddDemo.Framework.Models.DTO;

namespace TddDemo.Framework.UnitTest.Models.DTO
{
    public class AirportDtoTest
    {
        private static readonly Fixture Fixture = new Fixture();
        
        [Test]
        public void JsonSerializeTest()
        {
            var airport = Fixture.Create<AirportDto>();
            var serializedString = string.Format(@"{{""ThreeLetterCode"":""{0}"",""Airport"":""{1}""}}", airport.AirportCode, airport.AirportName);

            Assert.AreEqual(serializedString, JsonConvert.SerializeObject(airport));
            AssertionsHelper.AreEqualByJson(airport, JsonConvert.DeserializeObject<AirportDto>(serializedString));
        }
    }
}