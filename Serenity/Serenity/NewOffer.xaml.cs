using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Serenity
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NewOffer : ContentPage
	{
		public NewOffer()
		{
			InitializeComponent ();
            //HttpClient client = new HttpClient();
            //client.GetAsync("");
        }
        private async void ContentPage_Appearing(object sender, EventArgs e)
        {
            RestService service = new RestService();
            if (!string.IsNullOrWhiteSpace(StaticContext.Guuid))
            {
                LSTNewOffer.ItemsSource = await service.CheckAsync(Guid.Parse(StaticContext.Guuid));
            }
            else
            {
                await DisplayAlert("Offre invalide", "L'offre que vous venez de scanner est invalable", "ok");
            }

            
        }
    }
}