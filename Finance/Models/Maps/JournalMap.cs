using Dapper.FluentMap.Mapping;
using Finance.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Finance.Models.Maps
{
    public class JournalMap:EntityMap<JournalViewModel>
    {
        public JournalMap()
        {
            Map(x => x.TxnDate).ToColumn("Dateee", caseSensitive: false);
            Map(x => x.TxnType).ToColumn("Categoryyy", caseSensitive: false);
            Map(x => x.TxnAmt).ToColumn("Amounttt", caseSensitive: false);
            Map(x => x.Description).ToColumn("Remarkkk", caseSensitive: false);
        }
    }
}