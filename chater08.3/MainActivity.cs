using System;
using Android.App;
using Android.Widget;
using Android.OS;
using Android.Util;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace chater08._3
{
    [Activity(Label = "chater08._3", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        TextView locationText;
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
                temperature.Text = GetAPIToken().ToString();
            };
        }

        public string GetAPIToken()
        {
            // Log.Warn("aaaaaaaaaaaaaaaaaaaaaaaa", "a3");
            try
            {
                string apiBaseUri = "http://192.168.1.250:8088/";
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