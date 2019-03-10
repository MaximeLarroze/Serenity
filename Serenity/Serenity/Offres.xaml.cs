using Serenity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Serenity
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Offres : ContentPage
	{
		public Offres ()
		{
			InitializeComponent();
            
            //LSTOffre.ItemsSource = new List<Offre>
            //{
            //    new Offre{Remise = "5%", TOffre = "Café", Utilisation = "Valide"},
            //    new Offre{Remise = "8%", TOffre = "Croissants", Utilisation = "Valide"},
            //    new Offre{Remise = "10%", TOffre = "Café", Utilisation = "Valide"},
            //    new Offre{Remise = "12%", TOffre = "Thé", Utilisation = "Valide"},
            //    new Offre{Remise = "25%", TOffre = "Croissants", Utilisation = "Valide"},
            //    new Offre{Remise = "15%", TOffre = "Café", Utilisation = "Valide"}
            //};
        }

        private async void ContentPage_Appearing(object sender, EventArgs e)
        {
            RestService service = new RestService();
            LSTOffre.ItemsSource = await service.CheckAsync(new Guid("396c20e7-71c2-4d1d-9ac7-4cc49fa8bb2a"));
        }
    }
}