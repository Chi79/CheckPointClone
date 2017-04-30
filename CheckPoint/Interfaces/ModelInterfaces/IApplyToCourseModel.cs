using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPointCommon.ModelInterfaces
{
    public interface IApplyToCourseModel
    {
         IEnumerable<object> GetAppointmentsInCourse();

         IEnumerable<object> GetEmptyList();

        void ResetSessionState();

    }
}
