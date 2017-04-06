namespace CheckPointDataTables.Tables
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("APPOINTMENT")]
    public partial class APPOINTMENT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public APPOINTMENT()
        {
            ATTENDEEs = new HashSet<ATTENDEE>();
            READERs = new HashSet<READER>();
        }

        public int AppointmentId { get; set; }

        public int? CourseId { get; set; }

        public TimeSpan StartTime { get; set; }

        public TimeSpan EndTime { get; set; }

        public int PostalCode { get; set; }

        [Required]
        [StringLength(40)]
        public string AppointmentName { get; set; }

        [StringLength(200)]
        public string Description { get; set; }

        [StringLength(50)]
        public string Address { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date { get; set; }

        public bool? IsCancelled { get; set; }

        public bool? IsPrivate { get; set; }

        [Required]
        [StringLength(20)]
        public string UserName { get; set; }

        public bool? IsObligatory { get; set; }

        public virtual ADDRESS ADDRESS1 { get; set; }

        public virtual COURSE COURSE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ATTENDEE> ATTENDEEs { get; set; }

        public virtual CLIENT CLIENT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<READER> READERs { get; set; }
    }
}
