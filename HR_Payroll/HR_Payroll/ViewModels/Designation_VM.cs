using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HR_Payroll.Models
{
    [MetadataType(typeof(DesignationMetaData))]
    public partial class Designation
    {
    }

    public class DesignationMetaData
    {
        [Required(ErrorMessage = "Designation is Required")]
        [StringLength(30, MinimumLength = 1, ErrorMessage = "Max Length 30 characters & Max Length 1 Characters.")]
        public string Designation_Name { get; set; }
    }
}