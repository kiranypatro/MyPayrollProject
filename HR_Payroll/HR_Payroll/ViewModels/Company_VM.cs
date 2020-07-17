using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HR_Payroll.Models
{
    [MetadataType(typeof(Company_MetaData))]
    public partial class Company
    {
    }
    public class Company_MetaData
    {
        [Required(ErrorMessage = "Company Name Required")]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "Max Length 20 characters & Max Length 1 Characters.")]
        public string Company_Name { get; set; }
    }
}