﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPointCommon.ModelInterfaces
{
    public interface IAddSelectedAppointmentToCourseModel
    {
        int GetSessionAppointmentId();

        void SetSessionCourseId(int id);
    }
}