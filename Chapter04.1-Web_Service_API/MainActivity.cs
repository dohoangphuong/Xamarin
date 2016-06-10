using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Xml.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Json.NET;

namespace Chapter04._1_Web_Service_API
{
    //    public class RestService 
    //    {
    //        HttpClient client;
    //  public RestService()
    //        {
    //            client = new HttpClient();
    //            client.MaxResponseContentBufferSize = 256000;
    //  }
    //}
    [Activity(Label = "Chapter04._1_Web_Service_API", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        // Service1 ServiceLocal = new Service1();
        EditText txtA;
        EditText txtB;
        EditText txtResult;
        Button btnAdd;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);

            txtA = FindViewById<EditText>(Resource.Id.txtA);
            txtB = FindViewById<EditText>(Resource.Id.txtB);
            txtResult = FindViewById<EditText>(Resource.Id.txtResult);
            btnAdd = FindViewById<Button>(Resource.Id.btnAdd);

            //btnAdd.Click += btnAdd_Click;
        }

        public void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtA.Text == string.Empty)
            {
                Toast.MakeText(this, "Input in textbox a, please!", ToastLength.Short).Show();
                return;
            }

            if (txtB.Text == string.Empty)
            {
                Toast.MakeText(this, "Input in textbox b, please!", ToastLength.Short).Show();
                return;
            }
            int a = Convert.ToInt32(txtA.Text);
            int b = Convert.ToInt32(txtB.Text);

            //txtResult.Text = ServiceLocal.AddInt(a, b).ToString();

        }

        //      HttpClient client;

        //public RestService()
        //      {
        //          client = new HttpClient();
        //          client.MaxResponseContentBufferSize = 256000;
        //}
    }
}