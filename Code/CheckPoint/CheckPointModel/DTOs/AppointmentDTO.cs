using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPointModel.Validation;
using CheckPointDataTables.Tables;

namespace CheckPointModel.DTOs
{
    public class AppointmentDTO : AppointmentValidator
    {
        //TODO
       public string CourseId { get; set; }
       public string StartTime { get; set; }
       public string EndTime { get; set; }
       public string PostalCode { get; set; }
       public string AppointmentName { get; set; }
       public string Description { get; set; }
       public string Address { get; set; }
       public string Date { get; set; }
       public string UserName { get; set; }
       public bool IsCancelled { get; set; }
       public bool IsObligatory { get; set; }

        public override void CheckForBrokenRules(AppointmentDTO appointment)
        {
            base.CheckForBrokenRules(this);
        }
    }
}
