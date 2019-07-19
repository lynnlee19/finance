using Dapper.FluentMap;
using Finance.Models;
using Finance.Models.Maps;
using Finance.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Finance.Controllers
{
    public class HomeController : Controller
    {
        private AccountBookDAO dao = new AccountBookDAO();
        private readonly AccountBookService _AccountBookService;

        public HomeController()
        {
            _AccountBookService = new AccountBookService();
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AccountBook accountBook)
        {
            
            if (ModelState.IsValid)
            {
                accountBook.Id = Guid.NewGuid();
                _AccountBookService.Add(accountBook);
                _AccountBookService.Save();
                return RedirectToAction("Index");
            }

            return View(accountBook);
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
        [ChildActionOnly]
        public ActionResult SubAction()
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
    }
}