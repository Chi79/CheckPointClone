using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPointPOCOs.POCOs
{
    public class Appointment
    {
        public string AppointmentName { get; set; }
        public string Priority { get; set; }
        public string StartDate { get; set; }
        public string DueDate { get; set; }
        public string CompletionDate { get; set; }
        public bool Completed { get; set; }
    }
}
