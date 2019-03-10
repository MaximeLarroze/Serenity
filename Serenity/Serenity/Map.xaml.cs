using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using Plugin.Geolocator;
using Newtonsoft.Json;
using Serenity.Model;
using System.Net.Http;
using Android.Content;

namespace Serenity
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Map : ContentPage
    {
        public Map()
        {
            //this.Navigation.PushModalAsync(new MPage1());
            InitializeComponent();
            ChargementMAP.IsRunning = true;
            ChargementMAP.IsVisible = true;
            var WebViewMAP = new WebView
            {
                //Source = "https://www.waze.com/fr/livemap"
                Source = "https://www.google.com/"
            };
            ChargementMAP.IsRunning = false;
            ChargementMAP.IsVisible = false;
        }
        public async void Bt_Clicked_Urgence2(object sender, EventArgs e)
        {
            try
            {
                string numURG = "15";
                PhoneDialer.Open(numURG);
            }
            catch (Exception ex)
            {
                await DisplayAlert("Urgence", "Un erreur est survenue lors de l'appel des urgences \nComposez au plus vite le:\n15 pour le SAMU\n18 pour les Pompier\n17 pour la Police", "Ok");
            }
        }
        public async void Bt_Clicked_Aires(object sender, EventArgs e)
        {
            await this.Navigation.PushModalAsync(new Aires());
        }

        private async void ContentPage_Appearing(object sender, EventArgs e)
        {
            // Implémentation de l'API start
            var loc = await CrossGeolocator.Current.GetLastKnownLocationAsync();
            RestService service = new RestService();
            await service.SessionFollow(loc.Latitude, loc.Longitude);
        }
        public class MapTest
        {
            //public async Task NavigateToBuilding25(double lat, double lgt)
            //{
            //    var stringContent = new StringContent("{\"lat\":" + lat.ToString() + ", \"lgt\":" + lgt.ToString() + "}");
            //    var location = new Location(lat.ToString(), lgt.ToString());
            //    var options = new MapLaunchOptions
            //    {
            //        Name = "Microsoft Building 25"
            //    };
            //    await Map.OpenAsync(location, options);
            }
        private async void Bt_Clicked_SCAN(object sender, EventArgs e)
        {
            //SCAN
            //Intent intent = new Intent(Intent.ActionMain);
            //intent.AddCategory(Intent.CategoryHome);
            //StartActivity(intent);
            //Android.Content.Context.ActivityService.Contains
            
            //Activity a = Android

            
        }
    }
}