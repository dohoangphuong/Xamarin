using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace Chapter02._2_Event_Click_Show_Popup
{
    [Activity(Label = "Chapter02._2_Event_Click_Show_Popup", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        int count = 1;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button btnClickme = FindViewById<Button>(Resource.Id.btnClickme);

            //button.Click += delegate { button.Text = string.Format("{0} clicks!", count++); };
            btnClickme.Click += (object senser, EventArgs e) =>
            {
                Toast.MakeText(this, "Hi! Count: " + count++, ToastLength.Short).Show();
            };
        }
    }
}

