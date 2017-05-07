namespace CheckPointDataTables.Tables
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("COURSE")]
    public partial class COURSE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public COURSE()
        {
            APPOINTMENTs = new HashSet<APPOINTMENT>();
            ATTENDEEs = new HashSet<ATTENDEE>();
        }

        public int CourseId { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        [StringLength(200)]
        public string Description { get; set; }

        public bool? IsPrivate { get; set; }

        public bool IsObligatory { get; set; }

        [Required]
        [StringLength(20)]
        public string UserName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<APPOINTMENT> APPOINTMENTs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ATTENDEE> ATTENDEEs { get; set; }

        public virtual CLIENT CLIENT { get; set; }
    }
}
