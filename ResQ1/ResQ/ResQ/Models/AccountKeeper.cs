using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ResQ.Models
{
    public class AccountKeeper
    {
        [Display(Name="Введите текст")]
        public string NewValue { set; get; }
    }
}