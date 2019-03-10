using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace Serenity
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PSecours : ContentPage
	{
		public PSecours ()
		{
			InitializeComponent ();
		}
        public void Bt_Call_15(object sender, EventArgs e)
        {
            try
            {
                string numURG = "15";
                PhoneDialer.Open(numURG);
            }
            catch (Exception ex)
            {
                DisplayAlert("Urgence", "Un erreur est survenue lors de l'appel des urgences \nComposez au plus vite le:\n15 pour le SAMU\n18 pour les Pompier\n17 pour la Police", "Ok");
            }
        }
        public void Bt_Call_17(object sender, EventArgs e)
        {
            try
            {
                string numURG = "17";
                PhoneDialer.Open(numURG);
            }
            catch (Exception ex)
            {
                DisplayAlert("Urgence", "Un erreur est survenue lors de l'appel des urgences \nComposez au plus vite le:\n15 pour le SAMU\n18 pour les Pompier\n17 pour la Police", "Ok");
            }
        }
        public void Bt_Call_18(object sender, EventArgs e)
        {
            try
            {
                string numURG = "18";
                PhoneDialer.Open(numURG);
            }
            catch (Exception ex)
            {
                DisplayAlert("Urgence", "Un erreur est survenue lors de l'appel des urgences \nComposez au plus vite le:\n15 pour le SAMU\n18 pour les Pompier\n17 pour la Police", "Ok");
            }
        }
        public void Bt_Call_112(object sender, EventArgs e)
        {
            try
            {
                string numURG = "112";
                PhoneDialer.Open(numURG);
            }
            catch (Exception ex)
            {
                DisplayAlert("Urgence", "Un erreur est survenue lors de l'appel des urgences \nComposez au plus vite le:\n15 pour le SAMU\n18 pour les Pompier\n17 pour la Police", "Ok");
            }
        }
    }
}