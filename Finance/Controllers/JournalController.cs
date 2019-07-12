using Bogus;
using Finance.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Finance.Controllers
{
    public class JournalController : Controller
    {
        // GET: Journal
        public ActionResult Index()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult SubAction()
        {

            var faker = new Faker("zh_TW");
            var journals = new List<JournalViewModel>();
            for (int i = 0; i < 20; i++)
            {
                journals.Add(new JournalViewModel
                {
                    TxnDate = faker.Date.Past(),
                    TxnType = (EnumTxnType) faker.Random.Number(min: 1, max: 2),
                    TxnAmt = faker.Finance.Amount(min: 1, max: 5000)
                });
            }

            journals.Sort();

            return View(journals);
        }
    }
}