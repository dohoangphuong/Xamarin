using System;
using Android.App;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Net.Http;
using System.Collections.Generic;
using Xamarin;
using Newtonsoft.Json.Linq;
using Android.Util;
using System.Net.Http.Headers;

namespace Chapter04._2_Web_Service_Set
{
    [Activity(Label = "Chapter04._2_Web_Service_Set", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        TextView temperature;
        TextView locationText;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);


            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get the latitude/longitude EditBox and button resources:
            Button button = FindViewById<Button>(Resource.Id.getWeatherButton);

            // When the user clicks the button ...
            button.Click += (object senser, EventArgs e) =>
            {
                locationText = FindViewById<TextView>(Resource.Id.locationText);
                locationText.Text = GetAPIToken().ToString();
            };
        }

        public string GetAPIToken()
        {
            Log.Warn("aaaaaaaaaaaaaaaaaaaaaaaa", "a3");
            try
            {
                string apiBaseUri = "http://14.161.19.250:8088/";
                string userName = "hp.codoc@yahoo.com.vn";
                string password = "P@ssw0rd";
                Log.Info("a", userName);
                using (var client = new HttpClient())
                {
                    //setup client
                    client.BaseAddress = new Uri(apiBaseUri);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    //setup login data
                    var formContent = new FormUrlEncodedContent(new[]
                    {
                    new KeyValuePair<string, string>("grant_type", "password"),
                    new KeyValuePair<string, string>("username", userName),
                    new KeyValuePair<string, string>("password", password),
                 });
                    //send request
                    HttpResponseMessage responseMessage = client.PostAsync(apiBaseUri + "/Token", formContent).Result;

                    //get access token from response body
                    var responseJson = responseMessage.Content.ReadAsStringAsync().Result;
                    var jObject = JObject.Parse(responseJson);
                    return jObject.GetValue("access_token").ToString();
                }
            }
            catch (Exception ex)
            {
                return "";
            }
        }
    }
}