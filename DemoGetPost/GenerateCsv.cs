using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetPost
{
    internal class GenerateCsv
    {
        public static StringBuilder csv = new StringBuilder();
        public static void genrateCSV()
        {
            File.WriteAllText("E:\\csvData\\output.csv", csv.ToString());
        }
    }
}
