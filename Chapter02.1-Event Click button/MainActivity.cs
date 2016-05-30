using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace Chapter02._1_Event_Click_button
{
    [Activity(Label = "Chapter02._1_Event_Click_button", MainLauncher = true, Icon = "@drawable/icon")]
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
            //Button button = FindViewById<Button>(Resource.Id.MyButton);

            //button.Click += delegate { button.Text = string.Format("{0} clicks!", count++); };

            //Bắt đầu code
            Button btnClickme = FindViewById<Button>(Resource.Id.btnClickme);

            btnClickme.Click += (object sender, EventArgs e) =>
              {
                  btnClickme.Text = "Hello! My name is Phuong";
              };

        }
    }
}

