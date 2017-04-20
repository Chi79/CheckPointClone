namespace CheckPointDataTables.Tables
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CLIENT_TAG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CLIENT_TAG()
        {
            ATTENDEEs = new HashSet<ATTENDEE>();
        }

        [Key]
        [StringLength(30)]
        public string TagId { get; set; }

        [Required]
        [StringLength(20)]
        public string UserName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ATTENDEE> ATTENDEEs { get; set; }

        public virtual CLIENT CLIENT { get; set; }

        public virtual CLIENT CLIENT1 { get; set; }
    }
}
