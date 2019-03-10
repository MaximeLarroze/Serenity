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


namespace Serenity
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MPage1 : MasterDetailPage
    {
        public MPage1()
        {
            InitializeComponent();
            //Detail = new NavigationPage(new MPage1());
        }
        private void Bt_Clicked_Partir(object sender, EventArgs e)
        {
            StaticContext.AccessTimer = true;
            Detail = new Map();
            IsPresented = false;
        }
        private void Bt_Clicked_MonTimer(object sender, EventArgs e)
        {
            if (StaticContext.AccessTimer == true)
            {
                Detail = new TimerACT();
                IsPresented = false;
            }
        }
        private void Bt_Clicked_Offres(object sender, EventArgs e)
        {
            Detail = new Offres();
            IsPresented = false;
        }
        private void Bt_Clicked_PS(object sender, EventArgs e)
        {
            Detail = new PSecours();
            IsPresented = false;
        }
        private void Bt_CLicked_Urgence(object sender, EventArgs e)
        {
            Detail = new Urgence();
            IsPresented = false;
        }
        private void Bt_Clicked_Informations(object sender, EventArgs e)
        {
            Detail = new Informations();
            IsPresented = false;
        }
        private async void Bt_CLicked_Reset(object sender, EventArgs e)
        {
            RestService restService = new RestService();
            await restService.Reset();
            StaticContext.Starting = 0;
            StaticContext.AccessTimer = false;
            Detail = new MainPage();
            IsPresented = false;
        }


        private async void Bt_Clicked_Partir2(object sender, EventArgs e)
        {
            //TIMER
            Timer timer = new Timer(new List<TimeSpan>()
            {
                TimeSpan.FromMinutes(0.1),
                TimeSpan.FromMinutes(120),
                TimeSpan.FromMinutes(135)
            }, Timer);
            //FIN TIMER
            timer.Start();

            StaticContext.TempsRestant = TimeSpan.FromHours(2);
            Detail = new Map();
            IsPresented = false;
        }
        public bool Timer()
        {
            try
            {
                // Use default vibration length
                Vibration.Vibrate();

                // Or use specified time
                var duration = TimeSpan.FromSeconds(1);
                var duration2 = TimeSpan.FromSeconds(1);
                var duration3 = TimeSpan.FromSeconds(1);
                Vibration.Vibrate(duration);
                Vibration.Vibrate(duration2);
                Vibration.Vibrate(duration3);
            }
            catch (FeatureNotSupportedException ex)
            {
                // Feature not supported on device
            }
            catch (Exception ex)
            {
                // Other error has occurred.
            }
            Device.BeginInvokeOnMainThread(() => DisplayAlert("Temps de conduite dépassé", "Votre temps de conduite règlementaire est bientôt terminé\nPensez à prendre une pause sur la prochaine aire de repos\nVotre temps de repos doit être d'au moins 20 MINUTES", "ok"));
            return false;
        }

    }
}