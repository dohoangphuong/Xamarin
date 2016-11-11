using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;

namespace chapter08_01_WebService_Android_iOS
{
    public class MyClass
    {
        public string GetAPIToken()
        {
            try
            {
                string apiBaseUri = "http://192.168.1.250:8088/";
                string userName = "hp.codoc@yahoo.com.vn";
                string password = "P@ssw0rd";
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