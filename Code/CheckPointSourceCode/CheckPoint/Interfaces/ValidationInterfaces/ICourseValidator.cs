using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPointCommon.ValidationInterfaces
{
    interface ICourseValidator<T> : IValidator<T> where T : class
    {
        //TODO
    }
}
