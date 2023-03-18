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
    public class UsersData
    {
        public static async Task<ObservableCollection<UsersModel>> ShowUsers()
        {
            try
            {
                var client = new HttpClient();
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
