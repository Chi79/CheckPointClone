using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using CheckPointCommon.ServiceInterfaces;

namespace CheckPointHTTPServices.Cache
{
    public class SessionService : ISessionService
    {
        public string LoggedInClient
        {
            get
            {
                var client = HttpContext.Current.Session["LoggedInClient"].ToString();
                if(client != null)
                {
                    return client.ToString();
                }
                else
                {
                    return null;
                }
            }
            set { HttpContext.Current.Session["LoggedInClient"] = value; }
        }

        public bool? AddingAppointmentToCourseStatus
        {
            get
            {
                var addAppointmentStatus = HttpContext.Current.Session["AddingAppointmentToCourseStatus"];
                if(addAppointmentStatus != null)
                {
                    return (bool)addAppointmentStatus;
                }
                else
                {
                    return null;
                }
            }
            set { HttpContext.Current.Session["AddingAppointmentToCourseStatus"] = value; }
        }
        public int? SessionAppointmentId
        {
            get
            {
                var appointmentId = HttpContext.Current.Session["AppointmentId"];
                if(appointmentId != null)
                {
                    return (int)appointmentId;
                }
                else
                {
                    return null;
                }
            }
            set { HttpContext.Current.Session["AppointmentId"] = value; }
        }
        public int? SessionRowIndex
        {
            get
            {
                var rowIndex = HttpContext.Current.Session["MyRowIndex"];
                if(rowIndex != null)
                {
                    return (int)rowIndex;
                }
                else
                {
                    return null;
                }
            }
            set { HttpContext.Current.Session["MyRowIndex"] = value; }
        }
        public string ColumnName
        {
            get
            {
                var columnName = HttpContext.Current.Session["MySortExpression"];
                if(columnName != null)
                {
                    return columnName.ToString();
                }
                else
                {
                    return null;
                }
            }
            set { HttpContext.Current.Session["MySortExpression"] = value; }
        }
        public int? SessionCourseId
        {
            get
            {
                var sessionCourseId = HttpContext.Current.Session["CourseId"];
                if(sessionCourseId != null)
                {
                    return (int)sessionCourseId;
                }
                else
                {
                    return null;
                }
            }
            set { HttpContext.Current.Session["CourseId"] = value; }
        }
        public int? JobState
        {
            get
            {
                var jobState = HttpContext.Current.Session["job"];
                if(jobState != null)
                {
                    return (int)jobState;
                }
                else
                {
                    return null;
                }

            }
            set { HttpContext.Current.Session["job"] = value; }
        }
    }

}
