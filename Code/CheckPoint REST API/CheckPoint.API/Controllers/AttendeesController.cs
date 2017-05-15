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

    public class AttendeesController : ApiController
    {
        IUnitOfWork _unitOfWork;

        AttendeeMapper _attendeeMapper = new AttendeeMapper();

        public AttendeesController()
        {
            _unitOfWork = new UnitOfWork(new CheckPointContext());
        }

        public AttendeesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [Route("api/appointments/{appointmentId}/attendees", Name = "AttendeesForAppointment")]
        public IHttpActionResult GetAllAttendeesForAppointment(int appointmentId, string fields = null)
        {
            try
            {
                List<string> listOfFields = new List<string>();

                if (fields != null)
                {
                    listOfFields = fields.ToLower().Split(',').ToList();
                }

                var appointmentAttendees = _unitOfWork.Attendees.GetAllAttendeesForAppointment(appointmentId);

                if (appointmentAttendees == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(appointmentAttendees.ToList()
                            .Select(c => _attendeeMapper.CreateShapeDataObject(c, listOfFields)));
                }
            }
            catch (Exception)
            {

                return InternalServerError();
            }
        }

        [HttpGet]
        [Route("api/attendees/{appointmentId}/{tagId}", Name = "AppointmentAttendee")]
        public IHttpActionResult GetSingleAttendeeForAppointment(int appointmentId, string tagId)
        {
            try
            {

                var appointmentAttendee = _unitOfWork.Attendees.GetSingleAttendeeForAppointment(appointmentId, tagId);

                if (appointmentAttendee == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(appointmentAttendee);
                }
            }
            catch (Exception)
            {

                return InternalServerError();
            }
        }

        public IHttpActionResult GetAllAttendees(string fields = null)
        {
            try
            {
                List<string> listOfFields = new List<string>();

                if (fields != null)
                {
                    listOfFields = fields.ToLower().Split(',').ToList();
                }

                var attendees = _unitOfWork.Attendees.GetAllAttendees();
                return Ok(attendees.ToList()
                        .Select(c => _attendeeMapper.CreateShapeDataObject(c, listOfFields)));

            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }


        [HttpGet]
        public IHttpActionResult GetSingleAttendee(string id, string fields = null)
        {
            try
            {
                List<string> listOfFields = new List<string>();

                if (fields != null)
                {
                    listOfFields = fields.ToLower().Split(',').ToList();
                }

                var attendee = _unitOfWork.Attendees.GetSingleAttendee(id);

                if (attendee == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(_attendeeMapper.CreateShapeDataObject(attendee, listOfFields));
                }
            }
            catch (Exception)
            {

                return InternalServerError();
            }
        }
        [HttpPost]
        public IHttpActionResult AddSingleAttendee([FromBody] DTO.Attendee attendee)
        {
            try
            {
                if (attendee == null)
                {
                    return BadRequest();
                }

                var attendeeToAdd = _attendeeMapper.CreateAttendee(attendee);
                var result = _unitOfWork.Attendees.Insert(attendeeToAdd);

                if (result.Status == RepositoryActionStatus.Created)
                {
                    var newAttendee = _attendeeMapper.CreateAttendee(result.Entity);

                    return Created(Request.RequestUri + "/" + newAttendee.TagId.ToString(), newAttendee);
                }

                return BadRequest();
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        public IHttpActionResult UpdateEntireAttendee(int id, [FromBody]DTO.Attendee attendee)
        {
            try
            {
                if (attendee == null)
                {
                    return BadRequest();
                }

                //map
                var attendeeToUpdate = _attendeeMapper.CreateAttendee(attendee);
                var result = _unitOfWork.Attendees.UpdateAttendee(attendeeToUpdate);

                if (result.Status == RepositoryActionStatus.Updated)
                {
                    //map to dto
                    var updatedAttendee = _attendeeMapper.CreateAttendee(result.Entity);
                    return Ok(updatedAttendee);
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
        [Route("api/attendees/{id}/{id1}")]
        public IHttpActionResult UpdatePartialAttendee(int id, string id1, [FromBody]JsonPatchDocument<DTO.Attendee> attendeePatchDocument)
        {
            try
            {

                if (attendeePatchDocument == null)
                {
                    BadRequest();
                }

                var attendee = _unitOfWork.Attendees.GetSingleAttendeeForAppointment(id, id1);
                if (attendee == null)
                {
                    return NotFound();
                }

                //map
                var attendeeToUpdate = _attendeeMapper.CreateAttendee(attendee);

                //apply changes to the data transfer object
                attendeePatchDocument.ApplyTo(attendeeToUpdate);

                //map the DTO with applied changes to the entity, and update it
                var result = _unitOfWork.Attendees.UpdateAttendee(_attendeeMapper.CreateAttendee(attendeeToUpdate));

                if (result.Status == RepositoryActionStatus.Updated)
                {
                    //map to dto
                    var patchedAttendee = _attendeeMapper.CreateAttendee(result.Entity);
                    return Ok(patchedAttendee);
                }
                return BadRequest();

            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        public IHttpActionResult DeleteAttendeee(string id)
        {
            try
            {
                var result = _unitOfWork.Attendees.DeleteAttendee(id);

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
