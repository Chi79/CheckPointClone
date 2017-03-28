using System;

namespace CheckPoint.DTO
{
    public class Appointment
    {
        public string AppointmentName { get; set; }

        public DateTime Date { get; set; }

        public TimeSpan? StartTime { get; set; }

        public TimeSpan? EndTime { get; set; }

        public string Description { get; set; }

        public int AppointmentId { get; set; }

        //public int CourseId { get; set; }        

        //public int PostalCode { get; set; }

        //public string Address { get; set; }

        //public bool? IsCancelled { get; set; }

        //public string UserName { get; set; }

        public bool? IsObligatory { get; set; }
    }
}
