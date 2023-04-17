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
using Xamarin.Forms;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using static VistasSecuriDoor.Models.DoorsModel;

namespace VistasSecuriDoor.Data
{
    public class DoorsData
    {
        public static async Task<ObservableCollection<DoorsModel>> ShowDoors()
        {
            try
            {
                string token = Application.Current.Properties["token"] as string;
                var client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var placeResponse = await client.GetAsync("https://securidoor-web-api.onrender.com/api/places/");



                var responseContent = await placeResponse.Content.ReadAsStringAsync();


                Debug.WriteLine($"Response status code: {placeResponse.StatusCode}");
                Debug.WriteLine($"Response content: {responseContent}");

                if (placeResponse.IsSuccessStatusCode)
                {
                    var content = await placeResponse.Content.ReadAsStringAsync();
                    var places = JsonConvert.DeserializeObject<List<PlaceModel>>(content);

                    var doors = new ObservableCollection<DoorsModel>();
                    foreach (var place in places)
                    {
                        foreach (var room in place.rooms)
                        {
                            foreach (var door in room.doors)
                            {
                                Debug.WriteLine($"Door: {door.DoorName}");
                                var doorModel = new DoorsModel();
                                // asigna los valores a doorModel
                                doors.Add(doorModel);
                            }
                        }
                    }

                    return doors;
                }
                else
                {
                    Debug.WriteLine($"Server Error: {placeResponse.StatusCode} - {placeResponse.ReasonPhrase}");
                    return null;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Network Error: {ex.Message}");
                return null;
            }
        }
    }

        //public static async Task<ObservableCollection<DoorGroupModel>> GroupDoors()
        //{
        //    var doors = await ShowDoors().ConfigureAwait(false);
        //    var groups = await GroupData.ShowGroups().ConfigureAwait(false);

        //    var query = from door in doors
        //                join room in groups on door.DoorLocation[0] equals room.LocationId[0]
        //                group door by room.Location into g
        //                select new DoorGroupModel
        //                {
        //                    Location = g.Key,
        //                    GroupedDoors = new ObservableCollection<DoorsModel>(g)
        //                };

        //    return new ObservableCollection<DoorGroupModel>(query);
        //}


    }
