using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HR_Payroll.Models
{
    [MetadataType(typeof(HolidayMetaData))]
    public partial class Holiday
    {
    }
    public class HolidayMetaData
    {
        [Required(ErrorMessage = "Holiday is Required")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Max Length 100 characters & Max Length 1 Characters.")]
        public string Holiday_Name { get; set; }
        [Required(ErrorMessage = "Holiday Date is Required")]
        public Nullable<System.DateTime> Holiday_Date { get; set; }
    }
}