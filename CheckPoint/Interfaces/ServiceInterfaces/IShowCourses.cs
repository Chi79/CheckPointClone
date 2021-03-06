﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPointCommon.ServiceInterfaces
{
    public interface IShowCourses
    {
        IEnumerable<T> GetAllCoursesFor<T>(string client);
        IEnumerable<T> GetEmptyList<T>();

        IEnumerable<T> GetCoursesSortedByPropertyAscending<T>(string property);

        IEnumerable<T> GetCoursesSortedByPropertyDescending<T>(string property);

        IEnumerable<T> GetCoursesCached<T>();

        IEnumerable<T> GetPublicCoursesCached<T>();

        IEnumerable<T> GetPublicCoursesSortedByPropertyAscending<T>(string property);

        IEnumerable<T> GetPublicCoursesSortedByPropertyDescending<T>(string property);

        IEnumerable<T> GetAllPublicCourses<T>();

        object GetSelectedPublicCourseByCourseId(int? CourseId);
        object GetSelectedCourseByCourseId(int? CourseId);
    }
}
