using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Serenity.Droid;
using Xamarin.Forms;

[assembly:Dependency (typeof (Scan))]

namespace Serenity.Droid
{
    public class Scan : IScan
    {

        public void Scanner()
        {

            var activity = (Activity)Forms.Context;


            Intent intent = new Intent(Intent.ActionView, Android.Net.Uri.Parse("sty://pick/"));
            activity.StartActivityForResult(intent, 1);
            
            // activity.StartActivityForResult()
        }
    }
    
}