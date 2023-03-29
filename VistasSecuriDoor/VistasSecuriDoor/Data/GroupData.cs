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
    public class GroupData
    {
        public static async Task<ObservableCollection<DoorGroupModel>> ShowGroups() 
        {
            try 
            {
                var client = new HttpClient();
                var response = await client.GetAsync("https://securidoor-web-api.onrender.com/api/place");

                var responseContent = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<ObservableCollection<DoorGroupModel>>(content);
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
        }
    }
