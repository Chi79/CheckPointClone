using CheckPoint.Repository;
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
using System.Web.Http.Results;

namespace CheckPoint.API.Controllers
{
    
    public class ClientsController : ApiController
    {
        IUnitOfWork _unitOfWork;

        ClientMapper _clientMapper = new ClientMapper();

        public ClientsController()
        {
            _unitOfWork = new UnitOfWork(new CheckPointContext());
        }

        public ClientsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("api/clients/validate/{userName}/{password}", Name = "ValidateClient")]
        public IHttpActionResult ValidateClient(string userName, string password)
        {
            try
            {

                var validClient = _unitOfWork.Clients.ValidateClient(userName, password);

                if (validClient == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok("Client Validated");
                }

            }
            catch (Exception)
            {
                return BadRequest("Client could not be validated");
            }
        }


                

        public IHttpActionResult GetAllClients(string fields = null, string sort = "username")
        {
            try
            {
                List<string> listOfFields = new List<string>();

                if (fields != null)
                {
                    listOfFields = fields.ToLower().Split(',').ToList();
                }

                var clients = _unitOfWork.Clients.GetAllClients();
                return Ok(clients.ToList().OrderBy(a => a.UserName)
                        .Select(c => _clientMapper.CreateShapeDataObject(c, listOfFields)));
                        
            }
            catch (Exception)
            {
                return InternalServerError();                
            }
        }

        public IHttpActionResult GetSingleClient(string id, string fields = null)
        {
            try
            {
                List<string> listOfFields = new List<string>();

                if (fields != null)
                {
                    listOfFields = fields.ToLower().Split(',').ToList();
                }

                var client = _unitOfWork.Clients.GetSingleClient(id);

                if(client == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(_clientMapper.CreateShapeDataObject(client, listOfFields));
                }
            }
            catch (Exception)
            {

                return InternalServerError();
            }
        }
        [HttpPost]
        public IHttpActionResult AddSingleClient([FromBody] DTO.Client client)
        {
            try
            {
                if(client == null)
                {
                    return BadRequest();
                }

                var clientToAdd = _clientMapper.CreateClient(client);
                var result = _unitOfWork.Clients.Insert(clientToAdd);

                if(result.Status == RepositoryActionStatus.Created)
                {
                    var newClient = _clientMapper.CreateClient(result.Entity);

                    return Created(Request.RequestUri + "/" + newClient.UserName.ToString(), newClient);
                }

                return BadRequest();
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        public IHttpActionResult UpdateEntireClient(string id, [FromBody]DTO.Client client)
        {
            try
            {
                if(client == null)
                {
                    return BadRequest();
                }

                //map
                var clientToUpdate = _clientMapper.CreateClient(client);
                var result = _unitOfWork.Clients.UpdateClient(clientToUpdate);

                if(result.Status == RepositoryActionStatus.Updated)
                {
                    //map to dto
                    var updatedClient = _clientMapper.CreateClient(result.Entity);
                    return Ok(updatedClient);
                }
                else if(result.Status == RepositoryActionStatus.NotFound)
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
        public IHttpActionResult UpdatePartialClient(string id, [FromBody]JsonPatchDocument<DTO.Client> clientPatchDocument)
        {
            try
            {
                if(clientPatchDocument == null)
                {
                    BadRequest();
                }

                var client = _unitOfWork.Clients.GetSingleClient(id);
                if(client == null)
                {
                    return NotFound();
                }

                //map
                var clientToUpdate = _clientMapper.CreateClient(client);

                //apply changes to the data transfer object
                clientPatchDocument.ApplyTo(clientToUpdate);

                //map the DTO with applied changes to the entity, and update it
                var result = _unitOfWork.Clients.UpdateClient(_clientMapper.CreateClient(clientToUpdate));

                if(result.Status == RepositoryActionStatus.Updated)
                {
                    //map to dto
                    var patchedClient = _clientMapper.CreateClient(result.Entity);
                    return Ok(patchedClient);
                }
                return BadRequest();

            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        public IHttpActionResult DeleteClient(string id)
        {
            try
            {
                var result = _unitOfWork.Clients.DeleteClient(id);

                if(result.Status == RepositoryActionStatus.Deleted)
                {
                    return StatusCode(HttpStatusCode.NoContent);
                }
                else if(result.Status == RepositoryActionStatus.NotFound)
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
