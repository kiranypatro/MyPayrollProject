using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HR_Payroll.Models
{
    [MetadataType(typeof(GradeMetaData))]
    public partial class Grade
    {
    }
    public class GradeMetaData
    {
        [Required(ErrorMessage = "Designation is Required")]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "Max Length 20 characters & Max Length 1 Characters.")]
        public string Grade_Name { get; set; }
    }
}