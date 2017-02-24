namespace CheckPointDataTables.Tables
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ATTENDEE")]
    public partial class ATTENDEE
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AppointmentId { get; set; }

        [StringLength(200)]
        public string PersonalNote { get; set; }

        public DateTime? TimeAttended { get; set; }

        public int StatusId { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(30)]
        public string TagId { get; set; }

        public virtual APPOINTMENT APPOINTMENT { get; set; }

        public virtual ATTENDEE_STATUS ATTENDEE_STATUS { get; set; }

        public virtual CLIENT_TAG CLIENT_TAG { get; set; }
    }
}
