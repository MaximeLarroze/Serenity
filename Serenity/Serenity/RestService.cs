using Newtonsoft.Json;
using RestSharp;
using Serenity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Serenity
{
    public class RestService
    {
        public static Cookie cookie;
        public static string url = "http://192.168.1.130:8000";
        public RestService()
        {

        }

        public async Task<List<Aire>> GetAiresAsync()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("http://192.168.1.130:8000/api/aires");
            return JsonConvert.DeserializeObject<List<Aire>>(await response.Content.ReadAsStringAsync());
        }

        public async Task<List<Offre>> CheckAsync(Guid guid)
        {
            if (StaticContext.Starting == 0)
            {
                return null;
            }
            try
            {
                var client = new RestClient(url + "/api/check");
                client.CookieContainer = new CookieContainer();
                client.CookieContainer.Add(cookie);

                var request = new RestRequest(Method.POST);
                request.AddHeader("content-type", "application/json");
                var dico = new Dictionary<string, object>();
                dico.Add("uuid", guid);
                dico.Add("constraintEnabled", false);
                request.AddParameter("application/json", JsonConvert.SerializeObject(dico), ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);


                //HttpClient client = new HttpClient();
                //var dico = new Dictionary<string, string>();
                //dico.Add("uuid", guid.ToString());
                //var stringContent = new StringContent(JsonConvert.SerializeObject(dico));
                ////stringContent.Headers.Add("Content-Type", "application/json");
                //stringContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                //HttpResponseMessage response = await client.PostAsync("http://192.168.1.130:8000/api/check", stringContent);
                //string str = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Offre>>(response.Content);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task SessionStart(double lat, double lgt)
        {
            var client = new RestClient(url + "/api/session/start");
            var request = new RestRequest(Method.POST);
            request.AddHeader("content-type", "application/json");
            var dico = new Dictionary<string, double>();
            dico.Add("lat", lat);
            dico.Add("lgt", lgt);
            request.AddParameter("application/json", JsonConvert.SerializeObject(dico), ParameterType.RequestBody);
            client.ExecuteAsync(request, (response) =>
            {
                var responseCookie = response.Cookies.First();
                cookie = new Cookie(responseCookie.Name, responseCookie.Value, responseCookie.Path, responseCookie.Domain);
            });


            //HttpClient client = new HttpClient();
            //var dico = new Dictionary<string, double>();
            //dico.Add("lat", lat);
            //dico.Add("lgt", lgt);
            //var stringContent = new StringContent(JsonConvert.SerializeObject(dico));
            //stringContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            ////stringContent.Headers.Add("Content-Type", "application/json");
            //await client.PostAsync("http://192.168.0.163:8000/api/session/start", stringContent);
        }

        public async Task SessionFollow(double lat, double lgt)
        {
            var client = new RestClient(url + "/api/session/follow");
            client.CookieContainer = new CookieContainer();
            client.CookieContainer.Add(cookie);

            var request = new RestRequest(Method.POST);
            request.AddHeader("content-type", "application/json");
            var dico = new Dictionary<string, double>();
            dico.Add("lat", lat);
            dico.Add("lgt", lgt);
            request.AddParameter("application/json", JsonConvert.SerializeObject(dico), ParameterType.RequestBody);
            client.ExecuteAsync(request, (response) => { });

            //HttpClient client = new HttpClient();
            //var dico = new Dictionary<string, double>();
            //dico.Add("lat", lat);
            //dico.Add("lgt", lgt);
            //var stringContent = new StringContent(JsonConvert.SerializeObject(dico));
            //stringContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            ////stringContent.Headers.Add("Content-Type", "application/json");
            //await client.PostAsync("http://192.168.0.163:8000/api/session/follow", stringContent);
        }

        public async Task Reset()
        {
            var client = new RestClient(url + "/api/session/reset");
            var request = new RestRequest(Method.POST);
            request.AddHeader("content-type", "application/json");
            IRestResponse response = client.Execute(request);

            //HttpClient client = new HttpClient();
            //var stringContent = new StringContent("");
            //stringContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            ////stringContent.Headers.Add("Content-Type", "application/json");
            //await client.PostAsync("http://192.168.0.163:8000/api/session/reset", stringContent);
        }
    }
}