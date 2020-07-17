using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HR_Payroll.Models
{
    [MetadataType(typeof(Salary_Head_MetaData))]
    public partial class Salary_Head
    {
    }
    public class Salary_Head_MetaData
    {
        [Required(ErrorMessage = "Salary Head Code Required")]
        [StringLength(5, MinimumLength = 1, ErrorMessage = "Max Length 5 characters & Max Length 1 Characters.")]
        public string Salary_Head_Code { get; set; }
        [Required(ErrorMessage = "Salary Head Name Required")]
        [StringLength(30, MinimumLength = 1, ErrorMessage = "Max Length 30 characters & Max Length 1 Characters.")]
        public string Salary_Head_Name { get; set; }

        [Required(ErrorMessage = "Salary Head Type  Required")]
        
        public Nullable<int> Salary_Head_Type_ID { get; set; }
    }
}