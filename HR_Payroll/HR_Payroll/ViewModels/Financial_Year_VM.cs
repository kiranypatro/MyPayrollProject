using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HR_Payroll.Models
{
    [MetadataType(typeof(Financial_YearMetaData))]
    public partial class Financial_Year
    {
    }
    public class Financial_YearMetaData
    {
        [Required(ErrorMessage = "Financial Year is Required")]
        public Nullable<System.DateTime> Fin_Year { get; set; }
    }
}