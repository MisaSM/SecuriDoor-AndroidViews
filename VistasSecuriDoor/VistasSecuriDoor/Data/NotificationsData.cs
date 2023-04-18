using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using VistasSecuriDoor.Models;
using VistasSecuriDoor.ViewModels;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace VistasSecuriDoor.Data
{
    public class NotificationsData
    {
        public static async Task<ObservableCollection<NotificationsModel>> ShowNotification()
        {
            try
            {
                var client = new HttpClient();
                var response = await client.GetAsync("https://securidoor-web-api.onrender.com/api/photo/");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<ObservableCollection<NotificationsModel>>(content);
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

