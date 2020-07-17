using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace HR_Payroll.Models
{
    [MetadataType(typeof(BranchCodeMetaData))]
    public partial class Branch
    {
        

    }

    class BranchCodeMetaData
    {
    public int Branch_ID { get; set; }
    [Required(ErrorMessage = "Branch Name Required")]
    [StringLength(50, ErrorMessage = "Should not be more than 50 char")]
        public string Branch_Name { get; set; }
    public Nullable<int> Company_ID { get; set; }
    [StringLength(20, ErrorMessage = "Should not be more than 20 char")]
    //[Remote("IsCodeExists", "Employee", ErrorMessage = "Asset Code Name already in use")]
    public string Branch_Type { get; set; }

    [StringLength(20, ErrorMessage = "Should not be more than 20 char")]
    public string Land_Mark { get; set; }
    public Nullable<int> State_ID { get; set; }
    [Required(ErrorMessage = "City Name Required")]
    [StringLength(20, ErrorMessage = "Should not be more than 20 char")]
    public string City { get; set; }
    public Nullable<int> Country_ID { get; set; }
    [StringLength(20, ErrorMessage = "Should not be more than 20 char")]
    public string Pin_Code { get; set; }
    [StringLength(20, ErrorMessage = "Should not be more than 20 char.No")]
    [RegularExpression(@"^([0-9]{20})$", ErrorMessage = "Invalid Lanline Number.")]
    public string Landline_Number { get; set; }
    [StringLength(20, ErrorMessage = "Should not be more than 20 char.No")]
    [RegularExpression(@"^([0-9]{20})$", ErrorMessage = "Invalid Mobile Number.")]
    public string Mobile_Number { get; set; }
    [StringLength(20, ErrorMessage = "Should not be more than 20 char.No")]
    public string Email { get; set; }
    public string Branch_Head_Person_ID { get; set; }
    }
}