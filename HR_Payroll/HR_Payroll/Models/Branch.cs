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
    
    public partial class Branch
    {
        public int Branch_ID { get; set; }
        public string Branch_Name { get; set; }
        public Nullable<int> Company_ID { get; set; }
        public string Branch_Type { get; set; }
        public string Adress1 { get; set; }
        public string Adress2 { get; set; }
        public string Adress3 { get; set; }
        public string Land_Mark { get; set; }
        public Nullable<int> State_ID { get; set; }
        public string City { get; set; }
        public Nullable<int> Country_ID { get; set; }
        public string Pin_Code { get; set; }
        public string Landline_Number { get; set; }
        public string Mobile_Number { get; set; }
        public string Email { get; set; }
        public string Branch_Head_Person_ID { get; set; }
        public Nullable<System.DateTime> Creation_Date { get; set; }
        public string Create_By { get; set; }
        public Nullable<System.DateTime> Modified_Date { get; set; }
        public string Modified_By { get; set; }
    
        public virtual Company Company { get; set; }
        public virtual StateMaster StateMaster { get; set; }
    }
}
