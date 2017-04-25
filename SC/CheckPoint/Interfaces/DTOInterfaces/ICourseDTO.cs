using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPointCommon.DTOInterfaces
{
    public interface ICourseDTO
    {
        //TODO
        string Name { get; set; }
        string Description { get; set; }
        string UserName { get; set; }
        bool IsPrivate { get; set; }
        bool IsObligatory { get; set; }
        int CourseId { get; set; }
    }
}
