using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using VistasSecuriDoor.Models;
using VistasSecuriDoor.ViewModels;
using System.Threading.Tasks;

namespace VistasSecuriDoor.Data
{
    public class DoorsData
    {
        public static async Task<ObservableCollection<DoorsModel>> ShowDoors()
        {
            try
            {
                var request = new HttpRequestMessage();
                request.RequestUri = new Uri("http://www.securidoorapi.somee.com/api/doors");
                request.Method = HttpMethod.Get;

                var client = new HttpClient();
                HttpResponseMessage response = await client.SendAsync(request);

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<ObservableCollection<DoorsModel>>(content);

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

        public static async Task<ObservableCollection<DoorGroupModel>> ShowGroups()
        {
            var groups = await ShowDoors();

            var result = groups.GroupBy(d => d.DoorLocation);

            var groupsList = result.Select(g => new DoorGroupModel
            {
                Location = g.Key,
                GroupedDoors = new ObservableCollection<DoorsModel>(g.ToList())
            });

            return new ObservableCollection<DoorGroupModel>(groupsList);

        }


    }
}
