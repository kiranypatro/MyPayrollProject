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
    
    public partial class Employee_Leave_Enchasement
    {
        public int Leave_Enchasement_ID { get; set; }
        public Nullable<int> Emp_No { get; set; }
        public Nullable<int> Salary_Year { get; set; }
        public Nullable<int> Salary_Month { get; set; }
        public string Type_Of_Leave_Enchase { get; set; }
        public Nullable<decimal> Leave_Amount_Per_Unit { get; set; }
        public Nullable<decimal> Total_Amount { get; set; }
        public string Remark { get; set; }
        public Nullable<System.DateTime> Creation_Date { get; set; }
        public string Created_By { get; set; }
        public Nullable<System.DateTime> Modified_Date { get; set; }
        public string Modified_By { get; set; }
    
        public virtual Employee Employee { get; set; }
    }
}
