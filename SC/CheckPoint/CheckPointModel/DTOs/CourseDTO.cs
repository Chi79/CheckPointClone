using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPointCommon.DTOInterfaces;
using CheckPointModel.Validation;

namespace CheckPointModel.DTOs
{
    public class CourseDTO : CourseValidator, ICourseDTO
    {
        //TODO
        public string Name { get; set; }
        public string Description { get; set; }
        public string UserName { get; set; }
        public bool IsPrivate { get; set; }
        public bool IsObligatory { get; set; }
        public int CourseId { get; set; }

        public override void CheckForBrokenRules(ICourseDTO client)
        {
            base.CheckForBrokenRules(this);
        }
    }
}
