using System;
using Android.App;
using Android.Widget;
using Android.OS;
using System.Net.Http.Headers;

namespace chapter08_01_WebService_Android_iOS.Droid
{
	[Activity (Label = "chapter08_01_WebService_Android_iOS.Droid", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);


            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            Button button = FindViewById<Button>(Resource.Id.getWeatherButton);


            // When the user clicks the button ...
            button.Click += (object senser, EventArgs e) =>
            {
                TextView temperature = FindViewById<TextView>(Resource.Id.tempText);
                MyClass myClass = new MyClass();
                temperature.Text = myClass.GetAPIToken().ToString();
            };
        }     
    }
}