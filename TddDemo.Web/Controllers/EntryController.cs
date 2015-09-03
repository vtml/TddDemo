using System.Web.Mvc;
using TddDemo.Framework.Models.DataModels;
using TddDemo.Framework.Models.FormModels;
using TddDemo.Framework.Models.Mappers;

namespace TddDemo.Web.Controllers
{
    public class EntryController : Controller
    {
        private readonly IMapper<EntryFormModel, EntryDataModel> _mapper;

        public EntryController(IMapper<EntryFormModel, EntryDataModel> mapper)
        {
            _mapper = mapper;
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
            return entryDataModel.Airport != null ? RedirectToAction("Detail", new {entry = entryDataModel}) : RedirectToAction("Index");
        }

        public ActionResult Detail(EntryDataModel entry)
        {
            return View(entry);
        }
    }
}
