using Finance.Models;
using Finance.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace Finance.Service
{
    public class LogService
    {
        //private readonly SkillTreeHomeworkEntities _db;

        //public LogService()
        //{
        //    _db = new SkillTreeHomeworkEntities();
        //}
        private readonly IRepository<Log> _logRepository;

        public LogService(IUnitOfWork unitOfWork)
        {
            _logRepository = new Repository<Log>(unitOfWork);
        }
        public void Add(string txnCode, string txnDetail)
        {
            //_db.Log.Add(new Log
            //{
            //    TxnCode = txnCode,
            //    TxnDetail = txnDetail
            //});
            _logRepository.Create(new Log
            {
                TxnCode = txnCode,
                TxnDetail = txnDetail
            });
        }

        //public void Save()
        //{
        //    try
        //    {
        //        _db.SaveChanges();               
        //    }
        //    catch (DbUpdateConcurrencyException e)
        //    {
        //        string ErrorMsg = e.Message;
        //    }
        //    catch (Exception e)
        //    {
        //        string ErrorMsg = e.Message;
        //    }
        //}
    }
}