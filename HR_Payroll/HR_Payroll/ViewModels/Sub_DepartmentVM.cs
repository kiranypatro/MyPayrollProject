using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HR_Payroll.Models
{
    [MetadataType(typeof(Sub_DepartmentCodeMetaData))]
    public partial class Sub_Department
    {
        
    }

    public  class Sub_DepartmentCodeMetaData
    {
        [Required(ErrorMessage = "Sub Department Required")]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "Max Length 30 characters & Max Length 5 Characters.")]
        public string Sub_Department_Name { get; set; }
        [Required(ErrorMessage = "Department Name Required")]
        public Nullable<int> Department_ID { get; set; }

    }
}