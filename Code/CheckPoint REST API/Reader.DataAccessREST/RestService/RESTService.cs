using CheckPoint.DTO;
using Marvin.JsonPatch;
using Newtonsoft.Json;
using Reader.DataAccessREST.Helpers;
using ReaderCommon.DataAccessInterfaces;
using ReaderCommon.Enum;
using ReaderCommon.FactoryInterfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Reader.DataAccessREST
{
    public class RESTService : IDataAccess
    {
        //Attemts to validate the clients login information
        public async Task<bool> AttemptLogin(string userName, string password)
        {
            try
            {
                var httpClient = CheckPointHttpClient.GetHttpClient();
                HttpResponseMessage response = await httpClient.GetAsync("api/clients/validate/" + userName + "/" + password);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }

                return false;

            }
            catch (Exception)
            {

                return false;
            }
        }

        //Gets a collection of the host's appointments
        public async Task<IEnumerable<object>> GetHostAppointments(string hostUserName)
        {
            try
            {
                var httpClient = CheckPointHttpClient.GetHttpClient();

                HttpResponseMessage response = await httpClient.GetAsync("api/appointments/" + hostUserName);

                var content = await response.Content.ReadAsStringAsync();

                var hostAppointments = JsonConvert.DeserializeObject<IEnumerable<Appointment>>(content);

                return hostAppointments;

            }
            catch (Exception)
            {

                return null;
            }
        }
        //Gets the logged in host
        public async Task<Client> GetLoggedInHost(string userName)
        {
            try
            {
                var httpClient = CheckPointHttpClient.GetHttpClient();

                HttpResponseMessage response = await httpClient.GetAsync("api/clients/" + userName);

                var content = await response.Content.ReadAsStringAsync();

                var loggedInHost = JsonConvert.DeserializeObject<Client>(content);

               return loggedInHost;
                
            }
            catch (Exception)
            {

                return null;
            } 


        }
        //Checks to see if the attendee has already stamped, in order to not overwrite the first timestamp
        public async Task<bool> CheckIfHasAlreadyStamped(string appointmentId, string tagId)
        {
            try
            {
                var httpClient = CheckPointHttpClient.GetHttpClient();

                HttpResponseMessage response = await httpClient.GetAsync("api/attendees/" + appointmentId + "/" + tagId);

                string content = await response.Content.ReadAsStringAsync();

                var currentAttendee = JsonConvert.DeserializeObject<Attendee>(content);

                if (currentAttendee.TimeAttended != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                return false; //attendee doesnt exists
            }
            
            
            

        }

        //update attendee with a timestamp and correct attendeestatus
        
        public async Task<RegistrationFeedbackStatus> UpdateAttendeeWithStampAndStatus(string tagId, string appointmentId, bool isAppointmentObligatory)
        {
            try
            {
                var hasAlreadyStamped = await CheckIfHasAlreadyStamped(appointmentId, tagId);

                if (hasAlreadyStamped)
                {
                    return RegistrationFeedbackStatus.AlreadyRegistered;
                }

                var httpClient = CheckPointHttpClient.GetHttpClient();

                // create a JSON Patch Document
                JsonPatchDocument<Attendee> patchDoc = new JsonPatchDocument<Attendee>();
                //make changeset             
                patchDoc.Replace(c => c.TimeAttended, DateTime.Now);
                if (isAppointmentObligatory)
                {
                    patchDoc.Replace(c => c.StatusId, (int)AttendeeStatus.ObligHasAttended);
                }
                else
                {
                    patchDoc.Replace(c => c.StatusId, (int)AttendeeStatus.HasAttended);
                }

                // serialize from client object to json
                var serializedItemToUpdate = JsonConvert.SerializeObject(patchDoc);

                //PUT
                var response = await httpClient.PatchAsync("api/attendees/" + appointmentId + "/" + tagId,
                    new StringContent(serializedItemToUpdate,
                    System.Text.Encoding.Unicode, "application/json"));

                if(response.IsSuccessStatusCode)
                {
                    return RegistrationFeedbackStatus.Successful;
                }
                else
                {
                    return RegistrationFeedbackStatus.Failed;
                }
               
            }           
            catch
            {
                return RegistrationFeedbackStatus.NoDatabaseConnection;
            }
        }
    }
}
