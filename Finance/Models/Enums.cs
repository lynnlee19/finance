using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Finance.Models
{
    public enum EnumTxnType
    {
        [Description("收入")]
        Revenue = 1,

        [Description("支出")]
        Expense = 2
    };

}