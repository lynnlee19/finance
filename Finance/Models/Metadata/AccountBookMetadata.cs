using Finance.Models.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Finance.Models
{
    [MetadataType(typeof(AccountBookMetadata))]
    public partial class AccountBook
    {
        public class AccountBookMetadata
        {
            [Display(Name = "序號", Description = "交易序號")]
            public System.Guid Id { get; set; }

            [Required]
            [Display(Name = "類別", Description = "交易類別")]            
            public int Categoryyy { get; set; }

            [Required]
            [AmtRange(ErrorMessage = "金額必須為正整數")]
            [DisplayFormat(DataFormatString = "{0:N0}", ApplyFormatInEditMode = true)]
            [Display(Name = "金額", Description = "交易金額")]            
            public int Amounttt { get; set; }

            
            [Required]
            [DateRange(ErrorMessage= "日期必須小於今天")]
            [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
            [Display(Name = "日期", Description = "交易日期")]
            public System.DateTime Dateee { get; set; }

            [StringLength(20, ErrorMessage = " {0} 欄位長度應<= {1}")]
            [Display(Name = "備註", Description = "交易備註")]            
            public string Remarkkk { get; set; }
        }
    }
}