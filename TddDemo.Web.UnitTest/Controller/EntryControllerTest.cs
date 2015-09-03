using System.Web.Mvc;
using NSubstitute;
using NUnit.Framework;
using Ploeh.AutoFixture;
using TddDemo.Framework.Data;
using TddDemo.Framework.Models;
using TddDemo.Framework.Models.DataModels;
using TddDemo.Framework.Models.FormModels;
using TddDemo.Framework.Models.Mappers;
using TddDemo.Web.Controllers;

namespace TddDemo.Web.UnitTest.Controller
{
    public class EntryControllerTest
    {
        private readonly IMapper<EntryFormModel, EntryDataModel> _mapper = Substitute.For<IMapper<EntryFormModel, EntryDataModel>>();

        private static readonly Fixture Fixture = new Fixture();

        [TestFixtureSetUp]
        public void Setup()
        {
            Fixture.Register<IAirport>(Fixture.Create<Airport>);
        }
        
        [Test]
        public void Create_ShouldRedirectToIndex_WhenModelIsNotValid()
        {
            var entryDataModelRepository = Substitute.For<IRepository<EntryDataModel>>();
            var controller = new EntryController(_mapper, entryDataModelRepository);
            controller.ModelState.AddModelError(Fixture.Create<string>(), Fixture.Create<string>());

            var result = controller.Create(Fixture.Create<EntryFormModel>()) as RedirectToRouteResult;

            Assert.IsFalse(controller.ModelState.IsValid);
            Assert.IsNotNull(result);
            entryDataModelRepository.DidNotReceiveWithAnyArgs().Add(Arg.Any<EntryDataModel>());
            StringAssert.AreEqualIgnoringCase("Index", result.RouteValues["action"].ToString());
        }

        [Test]
        public void Create_ShouldRedirectToIndex_WhenAirportIsNull()
        {
            var entryDataModelRepository = Substitute.For<IRepository<EntryDataModel>>();
            var mapper = Substitute.For<IMapper<EntryFormModel, EntryDataModel>>();
            mapper.Map(Arg.Any<EntryFormModel>()).Returns(Fixture.Build<EntryDataModel>().With(x => x.Airport, null).Create());

            var controller = new EntryController(mapper, entryDataModelRepository);
            controller.ModelState.Clear();

            var result = controller.Create(Fixture.Create<EntryFormModel>()) as RedirectToRouteResult;

            Assert.IsTrue(controller.ModelState.IsValid);
            Assert.IsNotNull(result);
            entryDataModelRepository.DidNotReceiveWithAnyArgs().Add(Arg.Any<EntryDataModel>());
            StringAssert.AreEqualIgnoringCase("Index", result.RouteValues["action"].ToString());
        }

        [Test]
        public void Create_ShouldRedirectToDetail_WhenModelIsValidAndAirportIsNotNull()
        {
            var entryDataModelRepository = Substitute.For<IRepository<EntryDataModel>>();
            var entryDataModel = Fixture.Create<EntryDataModel>();
            var mapper = Substitute.For<IMapper<EntryFormModel, EntryDataModel>>();
            mapper.Map(Arg.Any<EntryFormModel>()).Returns(entryDataModel);

            var controller = new EntryController(mapper, entryDataModelRepository);
            controller.ModelState.Clear();

            var result = controller.Create(Fixture.Create<EntryFormModel>()) as RedirectToRouteResult;

            Assert.IsTrue(controller.ModelState.IsValid);
            Assert.IsNotNull(result);
            entryDataModelRepository.Received().Add(entryDataModel);
            StringAssert.AreEqualIgnoringCase("Detail", result.RouteValues["action"].ToString());
        }
    }
}
