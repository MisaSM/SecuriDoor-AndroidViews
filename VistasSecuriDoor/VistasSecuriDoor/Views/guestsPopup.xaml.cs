using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using VistasSecuriDoor.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VistasSecuriDoor.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class guestsPopup : Rg.Plugins.Popup.Pages.PopupPage
    {
        public guestsPopup()
        {
            InitializeComponent();
        }

        private async void postData(object sender, EventArgs e)
        {
            UsersModel user = new UsersModel
            {
                Name = guest_name.Text,
                userName = guest_user.Text,
                Password = guest_pwd.Text,
                IdRol = new string[] { "640ee55a7027f674e8df3772" }
            };

            try
            {
                Debug.WriteLine($"{user.Name} {user.userName} {user.Password} {user.IdRol}");
                Uri RequestUri = new Uri("https://securidoor-web-api.onrender.com/api/guest");
                var client = new HttpClient();
                var json = JsonConvert.SerializeObject(user);
                var contentJson = new StringContent(json, Encoding.UTF8, "application/json");
                var jsonString = await contentJson.ReadAsStringAsync();
                Debug.WriteLine(jsonString);
                var response = await client.PostAsync(RequestUri, contentJson);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    Debug.WriteLine($"Respuesta: {response.StatusCode}");
                    await DisplayAlert("Datos", "Se actualizo la información", "OK");
                }
                else
                {
                    Debug.WriteLine($"Server Error: {response.StatusCode} - {response.ReasonPhrase}");
                    Debug.WriteLine($"Respuesta: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Network Error: {ex.Message}");
            }

        }
    }
}