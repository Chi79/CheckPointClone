using CheckPoint.DTO;
using Marvin.JsonPatch;
using Newtonsoft.Json;
using RESTtest.Helpers;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace RESTtest
{
    class Program
    {
        //private static readonly string AllClients = "api/clients";
        static void Main(string[] args)
        {

            var client = GetSingleClient("carecopter");
            //Console.WriteLine(carecopter);
            Console.WriteLine();
            Console.ReadLine();

        }


        //fetch all clients
        public static async Task GetAllClients()
        {
            var httpclient = CheckPointHttpClient.GetHttpClient();
            HttpResponseMessage response = await httpclient.GetAsync("api/clients");

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                var listOfClients = JsonConvert.DeserializeObject<IEnumerable<Client>>(content);


                //return listOfClients;
                //print to console
                foreach (Client c in listOfClients)
                {
                    Console.WriteLine(c.UserName);
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("An error has occurred");
                
            }
        }

        public static async Task<Client> GetSingleClient(string id)
        {
            var httpclient = CheckPointHttpClient.GetHttpClient();
            HttpResponseMessage response = await httpclient.GetAsync("api/clients/" + id);


            string content = await response.Content.ReadAsStringAsync();
            var client = JsonConvert.DeserializeObject<Client>(content);

            return client; 

            
           
        }

        //patching single client
        public static async Task UpdateSingleClientPartial(string username, Client client)
        {
            try
            {
                var httpClient = CheckPointHttpClient.GetHttpClient();

                // create a JSON Patch Document
                JsonPatchDocument<Client> patchDoc = new JsonPatchDocument<Client>();

                //make changeset
                patchDoc.Replace(c => c.Address, "Homogata");
                patchDoc.Replace(c => c.LastName, "Tullebukk");

                // serialize from client object to json
                var serializedItemToUpdate = JsonConvert.SerializeObject(patchDoc);

                //PUT
                var response = await httpClient.PatchAsync("api/clients/" + username,
                    new StringContent(serializedItemToUpdate,
                    System.Text.Encoding.Unicode, "application/json"));

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Update successfull!");
                }
                else
                {
                    Console.WriteLine("An error occurred");
                }

            }
            catch
            {
                Console.WriteLine("An error occurred");
            }
        }

    }
}

