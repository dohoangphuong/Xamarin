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
using System.Net.Http;
using System.Json;
using System.Net;
using System.IO;
using Xamarin;
using System.Net.Http.Headers;
using Android.Util;
using System.Text;

namespace Chapter04._1_Web_Service_API
{
    [Activity(Label = "Chapter04._1_Web_Service_API", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);


            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get the latitude/longitude EditBox and button resources:
            EditText latitude = FindViewById<EditText>(Resource.Id.latText);
            EditText longitude = FindViewById<EditText>(Resource.Id.longText);
            Button button = FindViewById<Button>(Resource.Id.getWeatherButton);
            Log.Warn("aaaaaaaaaaaaaaaaaaaaaaaa", "a0");
            Button Test = FindViewById<Button>(Resource.Id.Test);
            Test.Click += (object senser, EventArgs e) =>
            {
                try
                {
                    throw new Exception("my exception");
                }
                catch (Exception exception)
                {
                    Insights.Report(exception);
                }
            };

            // When the user clicks the button ...
            button.Click += (object senser, EventArgs e) =>
                {

                    // Get the latitude and longitude entered by the user and create a query.
                    //string url = "http://api.geonames.org/findNearByWeatherJSON?lat=" +
                    //             latitude.Text +
                    //             "&lng=" +
                    //             longitude.Text +
                    //             "&username=demo";

                    // phan 1
                    // string url = "http://192.168.1.20/Help/Api/GET-api-DmQuan_portalId";

                    // Fetch the weather information asynchronously, 
                    // parse the results, then update the screen:
                    //JsonValue json = await FetchWeatherAsync(url);
                    //ParseAndDisplay (json);

                    Log.Warn("aaaaaaaaaaaaaaaaaaaaaaaa", "a1");
                    TextView temperature = FindViewById<TextView>(Resource.Id.tempText);
                    temperature.Text = GetAPIToken().ToString();
                };
        }
        // Gets weather data from the passed URL.
        //private async Task<JsonValue> FetchWeatherAsync(string url)
        //{
        //    // Create an HTTP web request using the URL:
        //    HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(new Uri(url));
        //    request.ContentType = "application/json";
        //    request.Method = "GET";

        //    // Send the request to the server and wait for the response:
        //    using (WebResponse response = await request.GetResponseAsync())
        //    {
        //        // Get a stream representation of the HTTP web response:
        //        using (Stream stream = response.GetResponseStream())
        //        {
        //            // Use this stream to build a JSON document object:
        //            JsonValue jsonDoc = await Task.Run(() => JsonObject.Load(stream));
        //            Console.Out.WriteLine("Response: {0}", jsonDoc.ToString());

        //            // Return the JSON document:
        //            return jsonDoc;
        //        }
        //    }
        //}

        public string GetAPIToken()
        {
            Log.Warn("aaaaaaaaaaaaaaaaaaaaaaaa", "a3");
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
                    Log.Warn("aaaaaaaaaaaaaaaaaaaaaaaa", responseJson.ToString());
                    var jObject = JObject.Parse(responseJson);
                    Log.Warn("aaaaaaaaaaaaaaaaaaaaaaaa", "A4");
                    return jObject.GetValue("access_token").ToString();
                }

            }
            catch (Exception ex)
            {
                return "";
            }
        }

        // Parse the weather data, then write temperature, humidity, 
        // conditions, and location to the screen.
        //private void ParseAndDisplay(JsonValue json)
        //{
        //    Log.Info("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
        //    // Get the weather reporting fields from the layout resource:
        //    TextView location = FindViewById<TextView>(Resource.Id.locationText);
        //    TextView temperature = FindViewById<TextView>(Resource.Id.tempText);
        //    TextView humidity = FindViewById<TextView>(Resource.Id.humidText);
        //    TextView conditions = FindViewById<TextView>(Resource.Id.condText);

        //    AlertDialog.Builder builder = new AlertDialog.Builder(this);
        //    builder.SetTitle("Confirmation");
        //    builder.SetMessage("Do you want to exit?");
        //    builder.SetCancelable(false);
        //    builder.SetNegativeButton("Yes", (object sender, DialogClickEventArgs e) =>
        //    {
        //        this.Finish();
        //    });
        //    builder.SetPositiveButton("No", (object sender, DialogClickEventArgs e) =>
        //    {
        //        //do code
        //    });

        //    AlertDialog dialog = builder.Create();
        //    temperature.Text = GetAPIToken().ToString();
        //    // Extract the array of name/value results for the field name "weatherObservation". 

        //    //string[][] newKeys = json;

        //    //string sd = JsonConvert.SerializeObject(newKeys);

        //    ////phan 1
        //    //JsonValue weatherResults = json[""];

        //    //// Extract the "stationName" (location string) and write it to the location TextBox:
        //    //location.Text = weatherResults["QuanID"];

        //    //temperature.Text = weatherResults["MaQuan"];

        //    //// Get the percent humidity and write it to the humidity TextBox:
        //    //humidity.Text = weatherResults["TenQuan"];

        //    //conditions.Text = weatherResults["NguoiTao"];


        //    ////JsonValue weatherResults = json["weatherObservation"];

        //    //// Extract the "stationName" (location string) and write it to the location TextBox:
        //    //location.Text = weatherResults["stationName"];

        //    //// The temperature is expressed in Celsius:
        //    //double temp = weatherResults["temperature"];
        //    //// Convert it to Fahrenheit:
        //    //temp = ((9.0 / 5.0) * temp) + 32;
        //    //// Write the temperature (one decimal place) to the temperature TextBox:
        //    //temperature.Text = String.Format("{0:F1}", temp) + "° F";

        //    //// Get the percent humidity and write it to the humidity TextBox:
        //    //double humidPercent = weatherResults["humidity"];
        //    //humidity.Text = humidPercent.ToString() + "%";

        //    //// Get the "clouds" and "weatherConditions" strings and 
        //    //// combine them. Ignore strings that are reported as "n/a":
        //    //string cloudy = weatherResults["clouds"];
        //    //if (cloudy.Equals("n/a"))
        //    //    cloudy = "";
        //    //string cond = weatherResults["weatherCondition"];
        //    //if (cond.Equals("n/a"))
        //    //    cond = "";

        //    //// Write the result to the conditions TextBox:
        //    //conditions.Text = cloudy + " " + cond;
        //}
    }
}