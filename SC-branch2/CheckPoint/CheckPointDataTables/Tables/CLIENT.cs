namespace CheckPointDataTables.Tables
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CLIENT")]
    public partial class CLIENT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CLIENT()
        {
            APPOINTMENTs = new HashSet<APPOINTMENT>();
            CLIENT_TAG = new HashSet<CLIENT_TAG>();
            CLIENT_TAG1 = new HashSet<CLIENT_TAG>();
        }

        [Required]
        [StringLength(30)]
        public string Email { get; set; }

        public int? PhoneNumber { get; set; }

        [Required]
        [StringLength(20)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(20)]
        public string LastName { get; set; }

        [Required]
        [StringLength(20)]
        public string Password { get; set; }

        [Key]
        [StringLength(20)]
        public string UserName { get; set; }

        [StringLength(50)]
        public string Address { get; set; }

        public int PostalCode { get; set; }

        public int ClientType { get; set; }

        public virtual ADDRESS ADDRESS1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<APPOINTMENT> APPOINTMENTs { get; set; }

        public virtual CLIENT_TYPE CLIENT_TYPE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLIENT_TAG> CLIENT_TAG { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLIENT_TAG> CLIENT_TAG1 { get; set; }
    }
}
