using Newtonsoft.Json.Linq;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.XPath;
using HtmlAgilityPack;

namespace GetPost
{
    internal class MultithreadedRequests
    {
        ConcurrentQueue<string> ts = new ConcurrentQueue<string>();
        

         
        
        public static async Task sendMultithreadedRequests(ConcurrentQueue<JToken> cQueue)
        {
            //string permalink = JsonParsing.permalink.ToString();

            try
            {
                Thread t1 = new Thread(() => sendMultithreadedRequests(cQueue));

                while (cQueue.IsEmpty)
                {
                    
                    //JToken link = cQueue.TryDequeue();

                    //using HttpResponseMessage response = await httpRequest.client.GetAsync(item.ToString());
                    //response.EnsureSuccessStatusCode();
                    //string responseBody = await response.Content.ReadAsStringAsync();
                    //Above three lines can be replaced with new helper method below
                    // string responseBody = await client.GetStringAsync(uri);

                    //string pattern = @"\bdiv\s\sdir=""ltr""";
                    //string pattern = @"<div\s*dir=""ltr"">(\n.*){21}";

                    //Match match = Regex.Match(responseBody, pattern);

                    

                    HtmlWeb web = new HtmlWeb();    
                    HtmlDocument doc = web.Load(cQueue.TryDequeue(out JsonParsing.permalink).ToString());

                    var node = doc.DocumentNode.SelectSingleNode("//*[@id=\"jbDetail\"]/div[1]/div");
                    Console.WriteLine(node.InnerText);
                    cQueue.TryDequeue(out JsonParsing.permalink);

                    //foreach (var iter in doc.DocumentNode.SelectNodes("//div[@dir='ltr']"))
                    //{
                    //    string desc =  
                    //}



                    //XmlNodeList nodes = doc.SelectNodes("//*[@id=\"jbDetail\"]/div[1]/div/ul");


                    //Console.WriteLine(match);




                    //MatchCollection mc = Regex.Matches(responseBody, pattern);
                    //mc.ToString();

                    //foreach (Match m in mc)
                    //{
                    //    Console.WriteLine(m);
                    //}


                    //Console.WriteLine(responseBody);
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
