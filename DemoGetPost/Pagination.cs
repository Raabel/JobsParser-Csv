using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetPost
{
    internal class Pagination
    {
        public async Task checkPagination()
        {
            if (JsonParsing.responseValues.ContainsKey("pagination"))
            {
                JObject pagination = (JObject)JsonParsing.responseValues["pagination"];

                if (pagination.ContainsKey("list"))
                {
                    JArray pageList = (JArray)pagination["list"];

                    for (int iter = 0; iter < pageList.Count; iter++)
                    { 
                        if (pageList[iter].Value<JToken>("lang").ToString().Equals("Next")) 
                        {
                            string fpn = pageList[iter].Value<JToken>("fpn").ToString();
                            httpRequest request = new httpRequest();
                            await request.SendRequest(fpn);
                        }
                    }

                }
            }
        }
    }
}
