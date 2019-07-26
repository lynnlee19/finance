using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Finance.Models.Attributes
{
    public class DateRangeAttribute : ValidationAttribute
    {
        public DateRangeAttribute()
        {

        }
        public override bool IsValid(object value)
        {
            if (value == null)
                return false;
            var compareDate = value as DateTime?;
            if (compareDate.HasValue)
            {
                compareDate = compareDate.Value.Date;
                return compareDate.Value <= DateTime.Today;
            }
            return false;
            
        }
        //public string GetErrorMessage()
        //{
        //    return $"日期必須小於今天.";
        //}
    }
}