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
using System.Net.Http.Headers;
using Xamarin.Forms;

namespace VistasSecuriDoor.Data
{
    public class UsersData
    {
        public static async Task<ObservableCollection<UsersModel>> ShowUsers()
        {
            try
            {
                string token = Application.Current.Properties["token"] as string;
                //if (Application.Current.Properties.ContainsKey("token"))
                //{
                //    token = 

                //    Debug.WriteLine($"Token adquirido! {token}");
                //}


                var client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var response = await client.GetAsync("https://securidoor-web-api.onrender.com/api/guest");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<ObservableCollection<UsersModel>>(content);
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
