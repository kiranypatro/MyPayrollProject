using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HR_Payroll.Models
{
    [MetadataType(typeof(DepartmentCodeMetaData))]
    public partial class Department
    {
    }
    public class DepartmentCodeMetaData
    {
        [Required(ErrorMessage = "Department Name Required")]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "Max Length 30 characters & Max Length 5 Characters.")]
        public string Department_Name { get; set; }
    }
}