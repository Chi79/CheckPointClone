﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPointCommon.ModelInterfaces
{
    public interface ICreateAppointmentModel<U,T> where U: class where T: class
    {
        U ConvertToAppointment(T entityModel);
        //TODO
    }
}