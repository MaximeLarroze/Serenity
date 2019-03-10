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
	public partial class Aires : ContentPage
	{
		public Aires ()
		{
			InitializeComponent ();
		}
        private async void ContentPage_Appearing_1(object sender, EventArgs e)
        {
            RestService service = new RestService();
            LSTAires.ItemsSource = await service.CheckAsync(new Guid("396c20e7-71c2-4d1d-9ac7-4cc49fa8bb2a"));
        }
    }
}