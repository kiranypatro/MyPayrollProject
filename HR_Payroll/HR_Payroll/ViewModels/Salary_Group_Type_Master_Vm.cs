using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HR_Payroll.Models
{
    [MetadataType(typeof(Salary_Group_Type_MasterMetaData))]
    public partial class Salary_Group_Type_Master
    {
    }
    public class Salary_Group_Type_MasterMetaData
    {
        [Required(ErrorMessage = "Salary Group Type Code Required")]
        [StringLength(5, MinimumLength = 1, ErrorMessage = "Max Length 5 characters & Max Length 1 Characters.")]
        public string Salary_Group_Type_Code { get; set; }

        [Required(ErrorMessage = "Type Required")]
        [StringLength(15, MinimumLength = 5, ErrorMessage = "Max Length 15 characters & Max Length 5 Characters.")]
        public string Type { get; set; }
        [Required(ErrorMessage = "Name Required")]
        [StringLength(20, MinimumLength =6, ErrorMessage = "Max Length 20 characters & Max Length 6 Characters.")]
        public string Name { get; set; }

    }
}