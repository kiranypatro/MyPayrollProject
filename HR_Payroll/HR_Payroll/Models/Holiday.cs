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
    
    public partial class Holiday
    {
        public int HolidayID { get; set; }
        public Nullable<int> ID { get; set; }
        public string Holiday_Name { get; set; }
        public Nullable<System.DateTime> Holiday_Date { get; set; }
        public string Day { get; set; }
        public Nullable<System.DateTime> Created_On { get; set; }
        public string Created_By { get; set; }
        public Nullable<System.DateTime> Modified_On { get; set; }
        public string Modified_By { get; set; }
    }
}
