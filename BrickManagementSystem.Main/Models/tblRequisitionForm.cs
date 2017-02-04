//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BrickManagementSystem.Main.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblRequisitionForm
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblRequisitionForm()
        {
            this.tblItemInfoes = new HashSet<tblItemInfo>();
            this.tblStocks = new HashSet<tblStock>();
        }
    
        public int ReqID { get; set; }
        public Nullable<int> CompanyID { get; set; }
        public string EmployeeName { get; set; }
        public string Purpose { get; set; }
        public Nullable<System.DateTime> RequestedDate { get; set; }
        public string CreatedBy { get; set; }
    
        public virtual mstCompanyInfo mstCompanyInfo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblItemInfo> tblItemInfoes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblStock> tblStocks { get; set; }
    }
}