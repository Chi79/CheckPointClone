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
                if (client != null)
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

        public string ClientTagId
        {
            get
            {
                var tagId = HttpContext.Current.Session["ClientTagId"].ToString();
                if(tagId!=null)
                {
                    return tagId;
                }
                else
                {
                    return null;
                }
            }
            set {
                HttpContext.Current.Session["ClientTagId"] = value;
            }
        }

        public bool? SavedChangesStatus
        {
            get
            {
                var savedChangesStatus = HttpContext.Current.Session["SavedChangesStatus"];
                if (savedChangesStatus != null)
                {
                    return (bool)savedChangesStatus;
                }
                else
                {
                    return null;
                }
            }
            set { HttpContext.Current.Session["SavedChangesStatus"] = value; }
        }

        public bool? NewAppointmentAddedToCourseStatus
        {
            get
            {
                var addAppointmentStatus = HttpContext.Current.Session["AddingAppointmentToCourseStatus"];
                if (addAppointmentStatus != null)
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
        public bool? AppliedToCourseStatus
        {
            get
            {
                var AppliedToCourseStatus = HttpContext.Current.Session["AppliedToCourseStatus"];
                if (AppliedToCourseStatus != null)
                {
                    return (bool)AppliedToCourseStatus;
                }
                else
                {
                    return null;
                }
            }
            set { HttpContext.Current.Session["AppliedToCourseStatus"] = value; }
        }

        public bool? AppointmentDeletedFromCourseStatus
        {
            get
            {
                var AppointmentDeletedStatus = HttpContext.Current.Session["DeletedAppointmentFromCourseStatus"];
                if (AppointmentDeletedStatus != null)
                {
                    return (bool)AppointmentDeletedStatus;
                }
                else
                {
                    return null;
                }
            }
            set { HttpContext.Current.Session["DeletedAppointmentFromCourseStatus"] = value; }
        }

        public bool? UpdatedCourseStatus
        {
            get
            {
                var CourseUpdatedStatus = HttpContext.Current.Session["UpdatedCourseStatus"];
                if (CourseUpdatedStatus != null)
                {
                    return (bool)CourseUpdatedStatus;
                }
                else
                {
                    return null;
                }
            }
            set { HttpContext.Current.Session["UpdatedCourseStatus"] = value; }
        }

        public bool? DeletedCourseStatus
        {
            get
            {
                var CourseDeletedStatus = HttpContext.Current.Session["DeletedCourseStatus"];
                if (CourseDeletedStatus != null)
                {
                    return (bool)CourseDeletedStatus;
                }
                else
                {
                    return null;
                }
            }
            set { HttpContext.Current.Session["DeletedCourseStatus"] = value; }
        }


        public int? SessionAppointmentId
        {
            get
            {
                var appointmentId = HttpContext.Current.Session["AppointmentId"];
                if (appointmentId != null)
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
                if (rowIndex != null)
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
                if (columnName != null)
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
                if (sessionCourseId != null)
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
        public int? JobType
        {
            get
            {
                var jobType = HttpContext.Current.Session["job"];
                if (jobType != null)
                {
                    return (int)jobType;
                }
                else
                {
                    return null;
                }

            }
            set { HttpContext.Current.Session["job"] = value; }
        }
        public string SessionAppointmentName
        {
            get
            {
                var sessionAppointmentName = HttpContext.Current.Session["appointmentName"];
                if (sessionAppointmentName != null)
                {
                    return (string)sessionAppointmentName;
                }
                else
                {
                    return null;
                }

            }
            set { HttpContext.Current.Session["appointmentName"] = value; }
        }
        public string SessionCourseName
        {
            get
            {
                var sessionCourseName = HttpContext.Current.Session["courseName"];
                if (sessionCourseName != null)
                {
                    return (string)sessionCourseName;
                }
                else
                {
                    return null;
                }

            }
            set { HttpContext.Current.Session["courseName"] = value; }
        }

        public bool? NavigationIsValid
        {
            get
            {
                var sessionNavigation = HttpContext.Current.Session["navigationIsValid"];
                if (sessionNavigation != null)
                {
                    return (bool)sessionNavigation;
                }
                else
                {
                    return null;
                }

            }
            set { HttpContext.Current.Session["navigationIsValid"] = value; }
        }

        public string SessionAttendeeUsername
        {
            get
            {
                var sessionAttendeeUsername = HttpContext.Current.Session["attendeeUsername"];
                if (sessionAttendeeUsername != null)
                {
                    return (string)sessionAttendeeUsername;
                }
                else
                {
                    return null;
                }

            }
            set { HttpContext.Current.Session["attendeeUsername"] = value; }
        }
    }

}
