//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EMCS.Data.DataModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class Asset
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Asset()
        {
            this.Images = new HashSet<Image>();
            this.Notes = new HashSet<Note>();
            this.Reservations = new HashSet<Reservation>();
            this.Specifications = new HashSet<Specification>();
        }
    
        public int ID { get; set; }
        public string SerialNumber { get; set; }
        public int CategoryID { get; set; }
        public int StatusID { get; set; }
        public int BrandID { get; set; }
        public int ModelID { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsArchived { get; set; }
    
        public virtual AssetCategory AssetCategory { get; set; }
        public virtual AssetStatusSVT AssetStatusSVT { get; set; }
        public virtual Brand Brand { get; set; }
        public virtual Model Model { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Image> Images { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Note> Notes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Reservation> Reservations { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Specification> Specifications { get; set; }
    }
}