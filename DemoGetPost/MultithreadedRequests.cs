using Newtonsoft.Json.Linq;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetPost
{
    internal class MultithreadedRequests
    {
        public async void sendMultithreadedRequests(ConcurrentQueue<JToken> cQueue)
        {
            //ConcurrentQueue<string> ts= new ConcurrentQueue<string> ();
            //Thread t1 = new Thread();

            //string permalink = JsonParsing.permalink.ToString();

            try
            {
                foreach (var item in cQueue)
                {
                    //JToken link = cQueue.TryDequeue();

                    using HttpResponseMessage response = await httpRequest.client.GetAsync(item.ToString());
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();
                    // Above three lines can be replaced with new helper method below
                    // string responseBody = await client.GetStringAsync(uri);

                    Console.WriteLine(responseBody);
                }
            }
            
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }

        }
    }
}
