using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Content;

namespace Serenity.Droid
{
    [Activity(Label = "Serenity", Icon = "@mipmap/icon", Theme = "@style/MainTheme", 
        MainLauncher = true, 
        LaunchMode = LaunchMode.SingleInstance,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)
        ]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
            

        }

        protected override void OnNewIntent(Intent intent)
        {
            base.OnNewIntent(intent);

            if(intent != null)
            {
                String uuid = intent.Data.Path.Substring(1);
                if(uuid != null)
                {
                    //TODO put into the app
                }
            }

        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            if(data != null && resultCode == Result.Ok)
            {
                String uuid = data.GetStringExtra("uuid");
                uuid.Trim();
            }

        }
    }
}