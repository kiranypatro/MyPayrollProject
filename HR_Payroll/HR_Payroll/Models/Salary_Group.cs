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
    
    public partial class Salary_Group
    {
        public int Salary_Group_ID { get; set; }
        public Nullable<int> Salary_Head_ID { get; set; }
        public Nullable<int> Salary_Group_Type_ID { get; set; }
        public string Calc_Type { get; set; }
        public Nullable<decimal> Amount_Percentage { get; set; }
        public Nullable<System.DateTime> Creation_Date { get; set; }
        public string Created_By { get; set; }
        public Nullable<System.DateTime> Modified_Date { get; set; }
        public string Modified_By { get; set; }
        public string PF_Applicable { get; set; }
        public string ESI_Applicable { get; set; }
        public string OT_Applicable { get; set; }
        public string Leave_Enchase_Applicable { get; set; }
    
        public virtual Salary_Head Salary_Head { get; set; }
        public virtual Salary_Group_Type_Master Salary_Group_Type_Master { get; set; }
    }
}