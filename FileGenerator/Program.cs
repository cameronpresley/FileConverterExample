using System;
using System.IO;
using FileGenerator.Core;
using FileGenerator.Services;
using FileGenerator.Services.FileWriters;

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

            var writer = new FileWriterFactory().CreateWriter(fileType);

            var parser = new CsvFileReader();
            var records = parser.RetrieveRecords(input);
            writer.WriteFile(fileName, records);
        }

        private static OutputFileType DetermineFileType(string fileName)
        {
            if (fileName.ToLower().EndsWith(".csv")) return OutputFileType.Csv;
            if (fileName.ToLower().EndsWith(".tsv")) return OutputFileType.Tsv;
            return OutputFileType.Unknown;
        }
    }
}
