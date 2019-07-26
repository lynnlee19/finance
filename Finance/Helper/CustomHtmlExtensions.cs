using Finance.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Finance.Helper
{
    public static class CustomHtmlExtensions
    {
        public static String DisplayCategoryColor(this HtmlHelper htmlHelper, EnumTxnType category)
        {
            var className = "";
            if (category == EnumTxnType.Revenue)
            {
                className = "text-success";
                
            }
            else if (category == EnumTxnType.Expense)
            {
                className = "text-danger";
            }

            return className;
        }
    }
}