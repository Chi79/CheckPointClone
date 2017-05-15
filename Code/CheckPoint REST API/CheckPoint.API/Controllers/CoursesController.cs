using CheckPoint.Repository.ConcreteRepositories;
using CheckPoint.Repository.Entities;
using CheckPoint.Repository.Mappers;
using CheckPoint.Repository.RepositoryInterfaces;
using Marvin.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CheckPoint.API.Controllers
{
  
    public class CoursesController : ApiController
    {
        IUnitOfWork _unitOfWork;

        CourseMapper _courseMapper = new CourseMapper();

        public CoursesController()
        {
            _unitOfWork = new UnitOfWork(new CheckPointContext());
        }

        public CoursesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IHttpActionResult GetAllCourses(string fields = null)
        {
            try
            {
                List<string> listOfFields = new List<string>();

                if (fields != null)
                {
                    listOfFields = fields.ToLower().Split(',').ToList();
                }

                var courses = _unitOfWork.Courses.GetAllCourses();
                return Ok(courses.ToList()
                        .Select(c => _courseMapper.CreateShapeDataObject(c, listOfFields)));

            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        public IHttpActionResult GetSingleCourse(int id, string fields = null)
        {
            try
            {
                List<string> listOfFields = new List<string>();

                if (fields != null)
                {
                    listOfFields = fields.ToLower().Split(',').ToList();
                }

                var course = _unitOfWork.Courses.GetSingleCourse(id);

                if (course == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(_courseMapper.CreateShapeDataObject(course, listOfFields));
                }
            }
            catch (Exception)
            {

                return InternalServerError();
            }
        }
        [HttpPost]
        public IHttpActionResult AddSingleCourse([FromBody] DTO.Course course)
        {
            try
            {
                if (course == null)
                {
                    return BadRequest();
                }

                var courseToAdd = _courseMapper.CreateCourse(course);
                var result = _unitOfWork.Courses.Insert(courseToAdd);

                if (result.Status == RepositoryActionStatus.Created)
                {
                    var newCourse = _courseMapper.CreateCourse(result.Entity);

                    return Created(Request.RequestUri + "/" + newCourse.CourseId.ToString(), newCourse);
                }

                return BadRequest();
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        public IHttpActionResult UpdateEntireCourse(int id, [FromBody]DTO.Course course)
        {
            try
            {
                if (course == null)
                {
                    return BadRequest();
                }

                //map
                var courseToUpdate = _courseMapper.CreateCourse(course);
                var result = _unitOfWork.Courses.UpdateCourse(courseToUpdate);

                if (result.Status == RepositoryActionStatus.Updated)
                {
                    //map to dto
                    var updatedCourse = _courseMapper.CreateCourse(result.Entity);
                    return Ok(updatedCourse);
                }
                else if (result.Status == RepositoryActionStatus.NotFound)
                {
                    return NotFound();
                }
                return BadRequest();
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [HttpPatch]
        public IHttpActionResult UpdatePartialCourse(int id, [FromBody]JsonPatchDocument<DTO.Course> coursePatchDocument)
        {
            try
            {
                if (coursePatchDocument == null)
                {
                    BadRequest();
                }

                var course = _unitOfWork.Courses.GetSingleCourse(id);
                if (course == null)
                {
                    return NotFound();
                }

                //map
                var courseToUpdate = _courseMapper.CreateCourse(course);

                //apply changes to the data transfer object
                coursePatchDocument.ApplyTo(courseToUpdate);

                //map the DTO with applied changes to the entity, and update it
                var result = _unitOfWork.Courses.UpdateCourse(_courseMapper.CreateCourse(courseToUpdate));

                if (result.Status == RepositoryActionStatus.Updated)
                {
                    //map to dto
                    var patchedCourse = _courseMapper.CreateCourse(result.Entity);
                    return Ok(patchedCourse);
                }
                return BadRequest();

            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        public IHttpActionResult DeleteCourse(int id)
        {
            try
            {
                var result = _unitOfWork.Courses.DeleteCourse(id);

                if (result.Status == RepositoryActionStatus.Deleted)
                {
                    return StatusCode(HttpStatusCode.NoContent);
                }
                else if (result.Status == RepositoryActionStatus.NotFound)
                {
                    return NotFound();
                }
                return BadRequest();
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }
    }
}
