using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Finance.Models.ViewModels
{
    public enum EnumTxnType { 收入 = 1, 支出 = 2 };

    public class JournalViewModel: IComparable<JournalViewModel>
    {
        [Display(Name = "日期", Description = "交易日期")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public System.DateTime TxnDate { get; set; }

        [Display(Name = "類別", Description = "類別")]
        public EnumTxnType TxnType { get; set; }

        [Display(Name = "備註", Description = "交易備註")]
        public string Description { get; set; }

        [DisplayFormat(DataFormatString = "{0:N0}", ApplyFormatInEditMode = true)]
        [Display(Name = "金額", Description = "交易金額")]
        public decimal TxnAmt { get; set; }

        public int CompareTo(JournalViewModel other)
        {
            if (other == null)
                return 1;

            else
                return this.TxnDate.CompareTo(other.TxnDate);
        }
    }
}