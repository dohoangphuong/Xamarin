using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Util;

namespace Chapter05._2_Open_Image
{
    [Activity(Label = "Chapter05._2_Open_Image", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.myButton);
            Log.Warn("aaaaaaaaaaaaaaaaaaaaaaaaaaaa", "A0");
            button.Click += delegate {
                Log.Warn("aaaaaaaaaaaaaaaaaaaaaaaaaaaa", "A011");
                var imageIntent = new Intent();
                imageIntent.SetType("image/*");
                imageIntent.SetAction(Intent.ActionGetContent);
                StartActivityForResult(
                    Intent.CreateChooser(imageIntent, "Select photo"), 0);
            };
            Log.Warn("aaaaaaaaaaaaaaaaaaaaaaaaaaaa", "A01");
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            Log.Warn("aaaaaaaaaaaaaaaaaaaaaaaaaaaa", "A1");
            base.OnActivityResult(requestCode, resultCode, data);

            if (resultCode == Result.Ok)
            {
                Log.Warn("aaaaaaaaaaaaaaaaaaaaaaaaaaaa", "A2");
                var imageView =
                    FindViewById<ImageView>(Resource.Id.myImageView);
                imageView.SetImageURI(data.Data);
            }
        }
    }
}

