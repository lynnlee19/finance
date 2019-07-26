using Dapper.FluentMap;
using Finance.Models;
using Finance.Models.Maps;
using Finance.Models.ViewModels;
using Finance.Repository;
using Finance.Service;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Finance.Helper;

namespace Finance.Controllers
{
    public class HomeController : Controller
    {
        private readonly AccountBookService _AccountBookService;
        private readonly LogService _LogService;
        private readonly UnitOfWork _unitOfWork;

        public HomeController()
        {
            _unitOfWork = new UnitOfWork();
            _AccountBookService = new AccountBookService(_unitOfWork);
            _LogService = new LogService(_unitOfWork);
        }
        private IList<SelectListItem> GetCategoryList()
        {
            IList<SelectListItem> list = Enum.GetValues(typeof(EnumTxnType))
                        .Cast<EnumTxnType>()
                        .Select(x => new SelectListItem
                        {
                            Text = Tools.GetEnumDescription(x),
                            Value = ((int)x).ToString()
                        })
                        .ToList();
            return list;
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            IList<SelectListItem> list =this.GetCategoryList();
            ViewData["categoryList"] = list;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Exclude = "Id")]AccountBook accountBook)
        {

            if (ModelState.IsValid)
            {
                accountBook.Id = Guid.NewGuid();
                _AccountBookService.Add(accountBook);
                _LogService.Add(ControllerContext.RouteData.Values["action"].ToString(), "Id=" + accountBook.Id.ToString());

                //_AccountBookService.Save();
                //_LogService.Save();
                _unitOfWork.Commit();
                return RedirectToAction("Index");
            }

            IList<SelectListItem> list = this.GetCategoryList();
            ViewData["categoryList"] = list;
            return View(accountBook);
        }
        //[ChildActionOnly]
        public ActionResult List()
        {

            //var faker = new Faker("zh_TW");
            //var journals = new List<JournalViewModel>();
            //for (int i = 0; i < 20; i++)
            //{
            //    journals.Add(new JournalViewModel
            //    {
            //        TxnDate = faker.Date.Past(),
            //        TxnType = (EnumTxnType) faker.Random.Number(min: 1, max: 2),
            //        TxnAmt = faker.Finance.Amount(min: 1, max: 5000)                    
            //    });
            //}

            //journals.Sort();

            //var journals = dao.GetAllAccountBooks();

            //return View(journals);

            return View(_AccountBookService.GetAll());
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

    }
}