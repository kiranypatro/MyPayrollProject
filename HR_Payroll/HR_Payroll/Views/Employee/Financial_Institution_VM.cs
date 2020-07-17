using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HR_Payroll.Models
{
    [MetadataType(typeof(Financial_InstitutionMetaData))]
    public partial class Financial_Institution
    {
    }
    public class Financial_InstitutionMetaData
    {
        [Required(ErrorMessage = "Name is Required")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Max Length 100 characters & Max Length 1 Characters.")]
        public string Name { get; set; }
    }
}