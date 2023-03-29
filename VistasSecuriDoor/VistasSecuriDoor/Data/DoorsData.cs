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
                var client = new HttpClient();
                var response = await client.GetAsync("https://securidoor-web-api.onrender.com/api/door");


                var responseContent = await response.Content.ReadAsStringAsync();

                
                Debug.WriteLine($"Response status code: {response.StatusCode}");
                Debug.WriteLine($"Response content: {responseContent}");

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<ObservableCollection<DoorsModel>>(content);
                }
                else
                {
                    Debug.WriteLine($"Server Error: {response.StatusCode} - {response.ReasonPhrase}");
                    return null;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Network Error: {ex.Message}");
                return null;
            }
        }

        public static async Task<ObservableCollection<DoorGroupModel>> GroupDoors()
        {
            var doors = await ShowDoors().ConfigureAwait(false);
            var groups = await GroupData.ShowGroups().ConfigureAwait(false);

            var query = from door in doors
                        join room in groups on door.DoorLocation[0] equals room.LocationId[0]
                        group door by room.Location into g
                        select new DoorGroupModel
                        {
                            Location = g.Key,
                            GroupedDoors = new ObservableCollection<DoorsModel>(g)
                        };

            return new ObservableCollection<DoorGroupModel>(query);
        }


    }
}
