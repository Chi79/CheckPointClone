using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReaderModel.Entities
{
    public class AppointmentModel
    {
        public int AppointmentID { get; set; }
        public int CourseId { get; set; }
        public string FromTime { get; set; }
        public string ToTime { get; set; }
        public string PostalCode { get; set; }
        public string AppointmentName { get; set; }
        public string Description { get; set; }
        public string StreetAddress { get; set; }
        public string Date { get; set; }
        public string UserName { get; set; }
        public bool Private { get; set; }
        public bool IsCancelled { get; set; }
        public bool IsObligatory { get; set; }
    }
}
