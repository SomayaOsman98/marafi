//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace marafi1.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class clients
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public clients()
        {
            this.shipment = new HashSet<shipment>();
        }
    
        public int ID_man { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public Nullable<int> value { get; set; }
        public Nullable<int> phone { get; set; }
        public string sender { get; set; }
        public Nullable<int> ID_comp { get; set; }
    
        public virtual Company Company { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<shipment> shipment { get; set; }
    }
}
