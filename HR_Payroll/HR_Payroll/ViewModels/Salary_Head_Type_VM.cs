using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HR_Payroll.Models
{
    [MetadataType(typeof(Salary_Head_Type_MetaData))]
    public partial class Salary_Head_Type
    {
    }

    public class Salary_Head_Type_MetaData
    {
        [Required(ErrorMessage = "Salary Head Type Name Required")]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "Max Length 20 characters & Max Length 1 Characters.")]
        public string Name_Salary_Head { get; set; }
    }
 }