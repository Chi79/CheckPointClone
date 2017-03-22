using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPointCommon.DTOInterfaces
{
    public interface IAppointmentDTO
    {
         string StartTime { get; set; }
         string EndTime { get; set; }
         string PostalCode { get; set; }
         string AppointmentName { get; set; }
         string Description { get; set; }
         string Address { get; set; }
         string Date { get; set; }
         string UserName { get; set; }
         bool IsCancelled { get; set; }
         bool IsObligatory { get; set; }
    }
}
