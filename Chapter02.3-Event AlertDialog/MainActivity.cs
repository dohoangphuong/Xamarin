using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace Chapter02._3_Event_AlertDialog
{
    [Activity(Label = "Chapter02._3_Event_AlertDialog", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        Button btnExit;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Main);

            AlertDialog.Builder builder = new AlertDialog.Builder(this);
            builder.SetTitle("Confirmation");
            builder.SetMessage("Do you want to exit?");
            builder.SetCancelable(false);
            builder.SetNegativeButton("Yes", (object sender, DialogClickEventArgs e) =>
            {
                this.Finish();
            });
            builder.SetPositiveButton("No", (object sender, DialogClickEventArgs e) =>
            {
                //do code
            });

            AlertDialog dialog = builder.Create();

            btnExit = FindViewById<Button>(Resource.Id.btnExit);

            //button.Click += delegate { button.Text = string.Format("{0} clicks!", count++); };
            btnExit.Click += (object senser, EventArgs e) =>
            {
                dialog.Show();
            };
        }
    }
}

