using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;
using Plugin.Geolocator;

namespace Serenity
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }
        
        public async void Bt_Clicked_Partir(object sender, EventArgs e)
        {
            Chargement.IsRunning = false;
            //TIMER
            Timer timer = new Timer(new List<TimeSpan>()
            {
                TimeSpan.FromMinutes(0.1),
                TimeSpan.FromMinutes(120),
                TimeSpan.FromMinutes(135)
            }, Timer);
            timer.Start();

            if (StaticContext.Timer2h != null)
                StaticContext.Timer2h.Stop();

            StaticContext.Timer2h = timer;

            StaticContext.Timer1s = new Timer(new List<TimeSpan>()
            {
                TimeSpan.FromSeconds(1)
            }, () =>
            {
                if (StaticContext.TempsRestant.TotalSeconds != 0)
                    StaticContext.TempsRestant = StaticContext.TempsRestant.Subtract(TimeSpan.FromSeconds(1));
                return true;
            });

            if (StaticContext.Timer1s != null)
                StaticContext.Timer1s.Stop();
            StaticContext.TempsRestant = TimeSpan.FromHours(2);
            StaticContext.Timer1s.Start();


            //FIN TIMER
            StaticContext.AccessTimer = true;
            await this.Navigation.PushModalAsync(new Map());
            await this.Navigation.PushAsync(new MPage1());
        }

        public bool Timer()
        {
            if (StaticContext.Verifiicat == true)
            {
                try
                {
                    // Use default vibration length
                    Vibration.Vibrate();

                    // Or use specified time
                    var duration = TimeSpan.FromSeconds(1);
                    Vibration.Vibrate(duration);
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
            }
           
            return false;
        }

        private async void ContentPage_Appearing(object sender, EventArgs e)
        {
            if (StaticContext.Starting == 0)
            {
                // Implémentation de l'API start
                var loc = await CrossGeolocator.Current.GetLastKnownLocationAsync();
                RestService service = new RestService();
                //RESET
                // await service.Reset():
                //START
                await service.SessionStart(loc.Latitude, loc.Longitude);
                StaticContext.Starting = 1;
            }
        }
    }
}
