﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReaderModel.Entities
{
    public class AttendeeModel
    {
        public int AppointmentId { get; set; }
        public string PersonalNote { get; set; }
        public DateTime TimeAttended { get; set; }
        public int StatusId { get; set; }
        public string TagId { get; set; }

    }
}