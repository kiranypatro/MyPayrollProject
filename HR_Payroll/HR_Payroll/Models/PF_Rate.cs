//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HR_Payroll.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class PF_Rate
    {
        public int PF_Rate_ID { get; set; }
        public Nullable<int> Fiancial_Year_ID { get; set; }
        public Nullable<decimal> Employee_Share_Percentage { get; set; }
        public Nullable<decimal> Employee_Share_Cut_Off { get; set; }
        public Nullable<decimal> Employer_Share_Pension_Percentage { get; set; }
        public Nullable<decimal> Employer_Share_PF_Percentage { get; set; }
        public Nullable<System.DateTime> Creation_Date { get; set; }
        public string Created_By { get; set; }
        public Nullable<System.DateTime> Modified_Date { get; set; }
        public string Modified_By { get; set; }
    
        public virtual Financial_Year Financial_Year { get; set; }
    }
}
