﻿using Newtonsoft.Json.Linq;
using System;
using System.Collections.Concurrent;
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
       private JToken jId;
       private JToken title;
       private JToken companyName;
       private JToken salary;
       private JToken experience;

        public static JToken permalink;
        ConcurrentQueue<JToken> cQueue = new ConcurrentQueue<JToken>();

        public static JObject responseValues;
        
        public async Task ParseJson(string responsebody)
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
                                jId = jposts[i].Value<JToken>("jid");
                            }

                            if (((JObject)jposts[i]).ContainsKey("title"))
                            {
                                title = jposts[i].Value<JToken>("title");
                            }

                            if (((JObject)jposts[i]).ContainsKey("permaLink"))
                            {
                                permalink = jposts[i].Value<JToken>("permaLink").ToString().Insert(0, "https://www.rozee.pk/");
                            }

                            if (((JObject)jposts[i]).ContainsKey("company_name"))
                            {
                                companyName = jposts[i].Value<JToken>("company_name");
                            }

                            if (((JObject)jposts[i]).ContainsKey("salaryNHide_exact")) 
                            {
                                salary = jposts[i].Value<JToken>("salaryNHide_exact");
                            }

                            if (((JObject)jposts[i]).ContainsKey("experience_text"))
                            {
                                experience = jposts[i].Value<JToken>("experience_text");
                            }

                            
                            cQueue.Enqueue(permalink);

                            string newline = string.Format("{0},{1},{2},{3},{4},{5}", title, jId, permalink, companyName, salary, experience);
                            GenerateCsv.csv.AppendLine(newline);
                        }
                    }
                }
            }
            
            MultithreadedRequests desc = new MultithreadedRequests();
            desc.sendMultithreadedRequests(cQueue);
            
            Pagination pagination= new Pagination();
            await pagination.checkPagination();
        }

    }

}

