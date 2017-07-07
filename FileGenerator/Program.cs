using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileGenerator.Services;

namespace FileGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllText(@"ExampleFiles\mock_data.csv");
            var parser = new CsvFileReader();
            var records = parser.RetrieveRecords(input);
            var x = 10;
        }
    }
}
