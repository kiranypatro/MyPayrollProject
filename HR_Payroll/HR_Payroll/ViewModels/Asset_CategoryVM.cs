using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HR_Payroll.Models
{
    [MetadataType(typeof(CategoryCodeMetaData))]
    public partial class Asset_Category
    {
             
    }
    public class CategoryCodeMetaData
    {
        [Remote("IsCateCodeExists", "Validation", ErrorMessage = "Asset Code Name already in use")]
        [Required(ErrorMessage = "Category Code Required")]
        [StringLength(10, MinimumLength = 3, ErrorMessage = "Max Length 10 characters & Max Length 3 Characters.")]
        public string Category_Code { get; set; }
        [Required(ErrorMessage ="Category Name Required")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Max Length 50 characters & Max Length 5 Characters.")]
        public string Category_Name { get; set; }
    }
  
}