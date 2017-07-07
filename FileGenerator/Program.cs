using System.IO;
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
            var writer = new CsvFileWriter();
            writer.WriteFile("kumquats.csv", records);
            var tsvWriter = new TsvFileWriter();
            tsvWriter.WriteFile("platypus.tsv", records);
        }
    }
}
