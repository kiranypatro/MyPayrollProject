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
    
    public partial class Financial_Institution
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Financial_Institution()
        {
            this.Financial_Institute_Employee_Mapping = new HashSet<Financial_Institute_Employee_Mapping>();
        }
    
        public int Financial_Institution_ID { get; set; }
        public string Name { get; set; }
        public Nullable<System.DateTime> Creation_Date { get; set; }
        public string Created_By { get; set; }
        public Nullable<System.DateTime> Modified_Date { get; set; }
        public string Modified_By { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Financial_Institute_Employee_Mapping> Financial_Institute_Employee_Mapping { get; set; }
    }
}