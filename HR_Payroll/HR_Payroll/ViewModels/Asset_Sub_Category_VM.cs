using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HR_Payroll.Models
{
    [MetadataType(typeof(Asset_Sub_Category_VM_Codemetadata))]
    public partial class Asset_Sub_Category
    {
    }

    public class Asset_Sub_Category_VM_Codemetadata
    {
        [Required(ErrorMessage = "Category Name is Required")]
        public Nullable<int> Asset_Category_ID { get; set; }

        [Required(ErrorMessage = "Sub Cat Code Required")]
        [StringLength(10, MinimumLength = 5, ErrorMessage = "Max Length 10 characters & Max Length 5 Characters.")]
        public string Sub_Category_Code { get; set; }

        [Required(ErrorMessage = "Category Name Required")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Max Length 50 characters & Max Length 5 Characters.")]
        public string Sub_Category_Name { get; set; }

        [Required(ErrorMessage = "Purchase Date Required")]
        public Nullable<System.DateTime> SubAsset_Purchase_Date { get; set; }
        [Required(ErrorMessage = "Warranty Date Required")]
        public Nullable<System.DateTime> SubAsset_Warranty_Date { get; set; }
    }
}