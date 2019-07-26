using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;


namespace Finance.Models.Attributes
{
    public class AmtRangeAttribute: ValidationAttribute
    {
        private decimal number;

        public AmtRangeAttribute()
        {

        }
        public override bool IsValid(object value)
        {
            decimal.TryParse(value.ToString(), NumberStyles.None, null, out number);
            if (value == null || number <= 0)
            {
                return false;
            }
            else
            {
                return (number == Math.Truncate(number));
            }
        }
        //public string GetErrorMessage()
        //{
        //    return $"金額必須為正整數.";
        //}
    }
}