﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPointCommon.ModelInterfaces
{
    public interface IManageAppointmentModel
    {
        //TODO
        object ConvertToAppointment(object entityModel);
        object ConvertToCourse(object entityModel);
    }
}
