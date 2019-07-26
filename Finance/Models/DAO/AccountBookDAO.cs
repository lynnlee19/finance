using Dapper;
using Finance.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace Finance.Models
{
    public class AccountBookDAO
    {
        private string ConnectionString { get; set; }

        public AccountBookDAO()
        {
            this.ConnectionString = WebConfigurationManager.ConnectionStrings["TestDB"].ConnectionString;
        }


        /// <summary>
        /// Inserts the specified f name.
        /// </summary>
        /// <param name="instance">The instance.</param>
        /// <returns></returns>
        //public int Insert(AccountBook instance)
        //{
        //    const string sqlStatement = "Insert Into AccountBook(Id, Dateee, Categoryyy, Amounttt, Remarkkk) Values (@Id, @Dateee, @Categoryyy, @Amounttt, @Remarkkk)";
   
        //    using (var conn = new SqlConnection(this.ConnectionString))
        //    {

        //        try
        //        {
        //            return conn.Execute(sqlStatement, new
        //            {
        //                Id = System.Guid.NewGuid().ToString(),
        //                Dateee = instance.Dateee,
        //                Categoryyy = instance.Categoryyy,
        //                Amounttt = instance.Amounttt,
        //                Remarkkk = instance.Remarkkk
        //            }) ;
        //        }
        //        catch (Exception)
        //        {
        //            //TODO 增加LOG
        //            throw;
        //        }
        //    }
        //}

        /// <summary>
        /// Updates the specified f name.
        /// </summary>
        /// <param name="instance">The instance.</param>
        /// <returns></returns>
        //public int Update(AccountBook instance)
        //{
        //    const string sqlStatement = "Update AccoutBook Set Dateee = @Dateee, Categoryyy = @Categoryyy, Amounttt=@Amounttt, Remarkkk=@Remarkkk Where Id = @Id ";

        //    using (var conn = new SqlConnection(this.ConnectionString))
        //    {
        //        try
        //        {
        //            return conn.Execute(sqlStatement, new
        //            {
        //                Dateee = instance.Dateee,
        //                Categoryyy = instance.Categoryyy,
        //                Amounttt = instance.Amounttt,
        //                Remarkkk = instance.Remarkkk
        //            });
        //        }
        //        catch (Exception)
        //        {
        //            //TODO 增加LOG
        //            throw;
        //        }
        //    }
        //}

        /// <summary>
        /// Deletes the specified id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        //public int Delete(int id)
        //{
        //    const string sqlStatement = "Delete From AccountBook Where Id = @Id ";

        //    using (var conn = new SqlConnection(this.ConnectionString))
        //    {
        //        try
        //        {
        //            return conn.Execute(sqlStatement, new
        //            {
        //                Id = id
        //            });
        //        }
        //        catch (Exception)
        //        {
        //            //TODO 增加LOG
        //            throw;
        //        }
        //    }
        //}

        /// <summary>
        /// Gets all authors.
        /// </summary>
        /// <returns></returns>
        public List<JournalViewModel> GetAllAccountBooks()
        {
            var result = new List<JournalViewModel>();

            const string sqlStatement = @"  Select Id, Dateee,
                                                 case Categoryyy when '0' then '1' else '2' end as Categoryyy, 
                                                 Amounttt, Remarkkk
                                            From AccountBook
                                            Order by Dateee desc";

            using (var conn = new SqlConnection(this.ConnectionString))
            {
                result = conn.Query<JournalViewModel>(sqlStatement).ToList();
            }
            return result;
        }

        /// <summary>
        /// Gets the author.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public JournalViewModel GetAcccountBook(Guid id)
        {
            var result = new JournalViewModel();

            const string sqlStatement = @"  Select Id, Dateee,
                                                 case Categoryyy when '0' then '1' else '2' end as Categoryyy, 
                                                 Amounttt, Remarkkk 
                                            From AccountBook Where Id = @Id";

            using (var conn = new SqlConnection(this.ConnectionString))
            {
                result = conn.Query<JournalViewModel>(sqlStatement,
                    new
                    {
                        Id = id
                    }).SingleOrDefault();
            }
            return result;
        }
        
    }
   
}