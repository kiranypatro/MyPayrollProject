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
    
    public partial class Salary_Head_Type
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Salary_Head_Type()
        {
            this.Salary_Head = new HashSet<Salary_Head>();
        }
    
        public int Salary_Head_Type_ID { get; set; }
        public string Name_Salary_Head { get; set; }
        public Nullable<System.DateTime> Creation_Date { get; set; }
        public string Created_By { get; set; }
        public Nullable<System.DateTime> Modified_Date { get; set; }
        public string Modified_By { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Salary_Head> Salary_Head { get; set; }
    }
}