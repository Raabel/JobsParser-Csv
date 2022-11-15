using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;

namespace GetPost
{
    internal class httpRequest
    {

        // HttpClient is intended to be instantiated once per application, rather than per-use. See Remarks.
        static readonly HttpClient client = new HttpClient();
        public static int i = -20;

        public static async Task SendRequest(string fpn)
        {
            try
            {
                //i += 20;
                //string temp = i.ToString();
                var msg = new Dictionary<string, string>
                {
                    { "filters[q]", "all" },
                    { "filters[fin]", "35" },
                    { "filters[fpn]", $"{fpn}" },
                    { "uid", "" },
                    { "rzTkn", "77a248ba842b267dee68fc51b23c5dfe6970ade5d74c458ea8ed376beb21f301" }
                };
                
                HttpResponseMessage response = await client.PostAsync("https://www.rozee.pk/services/job/jobsearch", new FormUrlEncodedContent(msg));
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                await JsonParsing.ParseJson(responseBody);
                
            }

            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
        }
    }
}
