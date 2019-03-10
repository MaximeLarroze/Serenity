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
	public partial class Informations : ContentPage
	{
		public Informations ()
		{
			InitializeComponent ();
		}
        public async Task SendEmail(string subject, string body, List<string> recipients)
        {
            try
            {
                subject = "Contact [Application Serenity]";
                body = "support@serenity.fr";
                var message = new EmailMessage
                {
                    Subject = subject,
                    Body = body,
                    To = recipients,
                    //Cc = ccRecipients,
                    //Bcc = bccRecipients
                };
                await Email.ComposeAsync(message);
            }
            catch (FeatureNotSupportedException fbsEx)
            {
                // Email is not supported on this device
            }
            catch (Exception ex)
            {
                // Some other exception occurred
            }
        }
    }
}