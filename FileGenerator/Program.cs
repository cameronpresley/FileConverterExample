using System;
using System.IO;
using System.Linq;
using FileGenerator.Core;
using FileGenerator.Services;

namespace FileGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllText(@"ExampleFiles\mock_data.csv");
            Console.WriteLine("What is the name of the output file?");
            var fileName = Console.ReadLine();

            var fileType = DetermineFileType(fileName);
            if (fileType != OutputFileType.Unknown)
            {
                var writer = new FileWriterFactory().CreateWriter(fileType);
                var parser = new CsvFileReader();
                var records = parser.RetrieveRecords(input);
                writer.WriteFile(fileName, records);
            }
            else
            {
                DisplayErrorScreen(fileName);
            }
        }

        private static void DisplayErrorScreen(string fileName)
        {
            if (fileName.Trim() == string.Empty)
                Console.WriteLine("Please specify a file name.");
            else
                Console.WriteLine("Couldn't figure out how to export a file with an extension of " +
                                  fileName.Split(new[] {"."}, StringSplitOptions.RemoveEmptyEntries).Last());
        }

        private static OutputFileType DetermineFileType(string fileName)
        {
            if (fileName.ToLower().EndsWith(".csv")) return OutputFileType.Csv;
            if (fileName.ToLower().EndsWith(".tsv")) return OutputFileType.Tsv;
            if (fileName.ToLower().EndsWith(".json")) return OutputFileType.Json;
            return OutputFileType.Unknown;
        }
    }
}
