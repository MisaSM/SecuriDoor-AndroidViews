using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Net;
using System.Threading.Tasks;
using VistasSecuriDoor.Models;

namespace VistasSecuriDoor.Data
{
    public class UsersData {
        public static async Task<ObservableCollection<UsersModel>> ShowUsers() {

            try
            {
                var request = new HttpRequestMessage();
                request.RequestUri = new Uri("http://www.securidoorapi.somee.com/api/users");
                request.Method = HttpMethod.Get;

                var client = new HttpClient();
                HttpResponseMessage response = await client.SendAsync(request);

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<ObservableCollection<UsersModel>>(content);

                    return result;
                }
                else
                {
                    Debug.WriteLine($"Server Error: {response.StatusCode} - {response.ReasonPhrase}");
                    return null;
                }


            }
            catch (Exception ex) 
            {
                Debug.WriteLine($"Hola! Soy lo que buscas. Network Error: {ex.Message}");
                return null;
            }


            
        }
    }
}
