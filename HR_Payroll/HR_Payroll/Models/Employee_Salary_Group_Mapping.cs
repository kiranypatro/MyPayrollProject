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
    
    public partial class Employee_Salary_Group_Mapping
    {
        public int Mapping_ID { get; set; }
        public Nullable<int> Emp_No { get; set; }
        public Nullable<int> Salary_Group_Type_ID { get; set; }
        public Nullable<System.DateTime> Creation_Date { get; set; }
        public string Created_By { get; set; }
        public Nullable<System.DateTime> Modified_Date { get; set; }
        public string Modified_By { get; set; }
    
        public virtual Employee Employee { get; set; }
        public virtual Salary_Group_Type_Master Salary_Group_Type_Master { get; set; }
    }
}
