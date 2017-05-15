using CheckPoint.Repository.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CheckPoint.Repository.ConcreteRepositories;
using CheckPoint.Repository.Mappers;
using CheckPoint.Repository.Entities;
using Marvin.JsonPatch;

namespace CheckPoint.API.Controllers
{

    public class AppointmentsController : ApiController
    {
        IUnitOfWork _unitOfWork;

        AppointmentMapper _appointmentMapper = new AppointmentMapper();

        public AppointmentsController()
        {
            _unitOfWork = new UnitOfWork(new CheckPointContext());
        }

        public AppointmentsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("api/appointments/{userName}", Name = "ClientsAppointments")]
        public IHttpActionResult GetAppointmentsForClient(string userName, string fields=null)
        {
            try
            {
                List<string> listOfFields = new List<string>();

                if (fields != null)
                {
                    listOfFields = fields.ToLower().Split(',').ToList();
                }

                var nextAppointment = _unitOfWork.Appointments.GetClientsAppointments(userName);

                if (nextAppointment == null)
                {
                    return BadRequest();
                }
                else
                {
                    return Ok(nextAppointment.ToList().OrderBy(a => a.Date)
                        .Select(a => _appointmentMapper.CreateShapeDataObject(a,listOfFields)));
                }

            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }


        public IHttpActionResult GetAllAppointments(string fields = null)
        {
            try
            {
                List<string> listOfFields = new List<string>();

                if (fields != null)
                {
                    listOfFields = fields.ToLower().Split(',').ToList();
                }

                var appointments = _unitOfWork.Appointments.GetAllAppointments();
                return Ok(appointments.ToList()
                        .Select(a => _appointmentMapper.CreateShapeDataObject(a, listOfFields)));

            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }



        public IHttpActionResult GetSingleAppointment(int id, string fields = null)
        {
            try
            {
                List<string> listOfFields = new List<string>();

                if (fields != null)
                {
                    listOfFields = fields.ToLower().Split(',').ToList();
                }

                var appointment = _unitOfWork.Appointments.GetSingleAppointment(id);

                if (appointment == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(_appointmentMapper.CreateShapeDataObject(appointment, listOfFields));
                }
            }
            catch (Exception)
            {

                return InternalServerError();
            }
        }

        
        
        //[HttpPost]
        //public IHttpActionResult AddSingleAppointment([FromBody] DTO.Appointment appointment)
        //{
        //    try
        //    {
        //        if (appointment == null)
        //        {
        //            return BadRequest();
        //        }

        //        var appointmentToAdd = _appointmentMapper.CreateAppointment(appointment);
        //        var result = _unitOfWork.Appointments.Insert(appointmentToAdd);

        //        if (result.Status == RepositoryActionStatus.Created)
        //        {
        //            var newAppointment = _appointmentMapper.CreateAppointment(result.Entity);

        //            return Created(Request.RequestUri + "/" + newAppointment.AppointmentId.ToString(), newAppointment);
        //        }

        //        return BadRequest();
        //    }
        //    catch (Exception)
        //    {
        //        return InternalServerError();
        //    }
        //}

        public IHttpActionResult UpdateEntireAppointment(int id, [FromBody]DTO.Appointment appointment)
        {
            try
            {
                if (appointment == null)
                {
                    return BadRequest();
                }

                //map
                var appointmentToUpdate = _appointmentMapper.CreateAppointment(appointment);
                var result = _unitOfWork.Appointments.UpdateAppointment(appointmentToUpdate);

                if (result.Status == RepositoryActionStatus.Updated)
                {
                    //map to dto
                    var updatedAppointment = _appointmentMapper.CreateAppointment(result.Entity);
                    return Ok(updatedAppointment);
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

        [HttpPatch] [HttpPut]
        public IHttpActionResult UpdatePartialAppointment(int id, [FromBody]JsonPatchDocument<DTO.Appointment> appointmentPatchDocument)
        {
            try
            {
                if (appointmentPatchDocument == null)
                {
                    BadRequest();
                }

                var appointment = _unitOfWork.Appointments.GetSingleAppointment(id);
                if (appointment == null)
                {
                    return NotFound();
                }

                //map
                var appointmentToUpdate = _appointmentMapper.CreateAppointment(appointment);

                //apply changes to the data transfer object
                appointmentPatchDocument.ApplyTo(appointmentToUpdate);

                //map the DTO with applied changes to the entity, and update it
                var result = _unitOfWork.Appointments.UpdateAppointment(_appointmentMapper.CreateAppointment(appointmentToUpdate));

                if (result.Status == RepositoryActionStatus.Updated)
                {
                    //map to dto
                    var patchedCourse = _appointmentMapper.CreateAppointment(result.Entity);
                    return Ok(patchedCourse);
                }
                return BadRequest();

            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        public IHttpActionResult DeleteAppointment(int id)
        {
            try
            {
                var result = _unitOfWork.Appointments.DeleteAppointment(id);

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
