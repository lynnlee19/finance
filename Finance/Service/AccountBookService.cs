using Finance.Models;
using Finance.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Finance.Service
{
    public class AccountBookService
    {
        private readonly SkillTreeHomeworkEntities _db;
        private AccountBookDAO _dao;

        public AccountBookService()
        {
            _db = new SkillTreeHomeworkEntities();
            _dao = new AccountBookDAO();
        }

        public IEnumerable<JournalViewModel> GetAll()
        {
            return _dao.GetAllAccountBooks();
        }

        public JournalViewModel GetSingle(Guid txnId)
        {
            return _dao.GetAcccountBook(txnId);
        }

        public void Add(AccountBook accountbook)
        {
            _db.AccountBook.Add(accountbook);
        }

        public void Edit(AccountBook pageData, AccountBook oldData)
        {
            oldData.Dateee = pageData.Dateee;
            oldData.Categoryyy = pageData.Categoryyy;
            oldData.Amounttt = pageData.Amounttt;
            oldData.Remarkkk = pageData.Remarkkk;
        }

        public void Delete(AccountBook accountBook)
        {
            _db.AccountBook.Remove(accountBook);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}