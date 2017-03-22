﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPointCommon.ViewInterfaces
{
    public interface IManageAttendanceView
    {
        event EventHandler<EventArgs> AcceptAttendeeForAppointment;

        IEnumerable<object> ApplicantsGridviewSource { set; }
        IEnumerable<object> AppointmentsGridviewSource { set; }
    }
}
