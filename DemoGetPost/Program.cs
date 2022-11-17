using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GetPost
{
    public class Program
    {
        static async Task Main()
        {
            Console.WriteLine("Please wait, we are fetching data of all Pages in the Business Development Category...");

            httpRequest request = new httpRequest();
            await request.SendRequest("0");

            

            GenerateCsv csv = new GenerateCsv();
            csv.genrateCSV();
            Console.WriteLine("CSV Generated!");

            //MultithreadedRequests multithreadedRequests = new MultithreadedRequests();
            //multithreadedRequests.sendMultithreadedRequests();
        }
    }
   
}
