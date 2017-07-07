using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using FileGenerator.Core;

namespace FileGenerator.Services
{
    public class TsvFileWriter
    {
        public void WriteFile(string fileLocation, List<Customer> customers)
        {
            if (File.Exists(fileLocation)) throw new ArgumentException("File already exists at " + fileLocation);
            using (var writer = new StreamWriter(fileLocation))
            {
                var columns = new List<string>
                {
                    "FName",
                    "Email",
                    "LName",
                    "PhysicalAddress",
                    "Company",
                    "DOB",
                };
                writer.WriteLine(String.Join("\t", columns));
                customers
                    .Select(x => new List<string>
                    {
                        x.FirstName,
                        x.EmailAddress,
                        x.LastName,
                        x.Address,
                        x.Company,
                        x.DateOfBirth.ToShortDateString()
                    }).Select(x => String.Join("\t", x))
                    .ToList()
                    .ForEach(writer.WriteLine);

                writer.Close();
            }
        }
    }
}
