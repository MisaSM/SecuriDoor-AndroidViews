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
                using (var request = new HttpRequestMessage())
                {
                    request.RequestUri = new Uri("http://www.securidoorapi.somee.com/api/doors");
                    request.Method = HttpMethod.Get;

                    using (var client = new HttpClient())
                    {
                        HttpResponseMessage response = await client.SendAsync(request).ConfigureAwait(false);

                        switch (response.StatusCode)
                        {
                            case HttpStatusCode.OK:
                                string content = await response.Content.ReadAsStringAsync();
                                var result = JsonConvert.DeserializeObject<ObservableCollection<DoorsModel>>(content);
                                return result;

                            case HttpStatusCode.NotFound:
                                Debug.WriteLine("Server Error: Not Found");
                                return null;

                            default:
                                Debug.WriteLine($"Server Error: {response.StatusCode} - {response.ReasonPhrase}");
                                return null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Network Error: {ex.Message}");
                return null;
            }
        }

        public static async Task<ObservableCollection<DoorGroupModel>> ShowGroups()
        {
            var groups = await ShowDoors().ConfigureAwait(false);

            var result = groups.GroupBy(d => d.DoorLocation);

            var groupsList = result.Select(g => new DoorGroupModel
            {
                Location = g.Key,
                GroupedDoors = new ObservableCollection<DoorsModel>(g)
            });

            return new ObservableCollection<DoorGroupModel>(groupsList);
        }


    }
}
