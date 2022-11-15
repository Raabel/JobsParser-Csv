using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GetPost
{
    public class JsonParsing
    {
       public static JToken first;
       public static JToken second;
       public static JToken third;
       public static JToken fourth;
       public static JToken fifth;
       public static JToken sixth;

       public static JObject responseValues;

        public static async Task ParseJson(string responsebody)
        {
            string ResponseBody = responsebody;
         
            JObject o = JObject.Parse(ResponseBody);

            if (o.ContainsKey("response"))
            {
                responseValues = (JObject)o["response"];

                if (responseValues.ContainsKey("jobs"))
                {
                    JObject jobValues = (JObject)responseValues["jobs"];

                    if (jobValues.ContainsKey("basic"))
                    {
                        JArray jposts = (JArray)jobValues["basic"];

                        for (int i = 0; i < jposts.Count; i++)
                        {
                            if (((JObject)jposts[i]).ContainsKey("jid"))
                            {
                                first = jposts[i].Value<JToken>("jid");
                            }

                            if (((JObject)jposts[i]).ContainsKey("title"))
                            {
                                second = jposts[i].Value<JToken>("title");
                            }

                            if (((JObject)jposts[i]).ContainsKey("description"))
                            {
                                third = jposts[i].Value<JToken>("description").ToString().Replace(",", "").Replace("\n", "");
                            }

                            if (((JObject)jposts[i]).ContainsKey("company_name"))
                            {
                                fourth = jposts[i].Value<JToken>("company_name");
                            }

                            if (((JObject)jposts[i]).ContainsKey("salaryNHide_exact"))
                            {
                                fifth = jposts[i].Value<JToken>("salaryNHide_exact");
                            }

                            if (((JObject)jposts[i]).ContainsKey("experience_text"))
                            {
                                sixth = jposts[i].Value<JToken>("experience_text");
                            }

                            string newline = string.Format("{0},{1},{2},{3},{4},{5}", first, second, third, fourth, fifth, sixth);
                            GenerateCsv.csv.AppendLine(newline);
                        }
                    }
                }
            }
            
            await Pagination.checkPagination();
        }

    }

}

