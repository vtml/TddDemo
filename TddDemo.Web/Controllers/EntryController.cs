using System.Web.Mvc;
using TddDemo.Framework.Data;
using TddDemo.Framework.Models.DataModels;
using TddDemo.Framework.Models.FormModels;
using TddDemo.Framework.Models.Mappers;

namespace TddDemo.Web.Controllers
{
    public class EntryController : Controller
    {
        private readonly IMapper<EntryFormModel, EntryDataModel> _mapper;
        private readonly IRepository<EntryDataModel> _entryDataModelRepository;

        public EntryController(IMapper<EntryFormModel, EntryDataModel> mapper, IRepository<EntryDataModel> entryDataModelRepository)
        {
            _mapper = mapper;
            _entryDataModelRepository = entryDataModelRepository;
        }

        public ActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EntryFormModel entry)
        {
            if (!ModelState.IsValid) return RedirectToAction("Index");
            var entryDataModel = _mapper.Map(entry);
            if (entryDataModel.Airport == null) return RedirectToAction("Index");
            _entryDataModelRepository.Add(entryDataModel);
            return RedirectToAction("Detail", new {entry = entryDataModel});
        }

        public ActionResult Detail(EntryDataModel entry)
        {
            return View(entry);
        }
    }
}
