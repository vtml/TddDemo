using Newtonsoft.Json;
using NUnit.Framework;

namespace TddDemo.Framework.UnitTest
{
    public static class AssertionsHelper
    {
        /// <summary>
        /// Converts 2 objects into Json and compare every single property
        /// http://stackoverflow.com/questions/318210/compare-equality-between-two-objects-in-nunit
        /// </summary>
        /// <param name="expected"></param>
        /// <param name="actual"></param>
        public static void AreEqualByJson(object expected, object actual)
        {
            var expectedJson = JsonConvert.SerializeObject(expected);
            var actualJson = JsonConvert.SerializeObject(actual);
            Assert.AreEqual(expectedJson, actualJson);
        }
    }
}
