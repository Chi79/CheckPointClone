using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPointCommon.ServiceInterfaces;

namespace CheckPointCommon.ServiceInterfaces
{
    public interface IHandleCourses : IHandler
    {
        IEnumerable<T> GetAllCoursesForClient<T>(string client);

        IEnumerable<string> GetAllCourseNamesForClient(string client);

        object GetCourseToDisplay();

        object GetCourseByName(string courseName);

        object GetCourseById(int courseId);

    }
}
