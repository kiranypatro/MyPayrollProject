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
    
    public partial class Communication_Address
    {
        public int ID { get; set; }
        public Nullable<int> Emp_No { get; set; }
        public string Plot_No { get; set; }
        public string Flat_No { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public Nullable<int> Country_ID { get; set; }
        public Nullable<int> State_ID { get; set; }
        public Nullable<int> City_ID { get; set; }
        public string Pin_Code { get; set; }
        public string Land_Mark { get; set; }
        public Nullable<System.DateTime> Creation_Date { get; set; }
        public string Created_By { get; set; }
        public Nullable<System.DateTime> Modified_Date { get; set; }
        public string Modified_By { get; set; }
        public string Flag { get; set; }
    }
}
