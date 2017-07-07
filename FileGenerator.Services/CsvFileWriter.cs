using System;
using System.Collections.Generic;
using System.IO;
using FileGenerator.Core;

namespace FileGenerator.Services
{
    public class CsvFileWriter
    {
        public void WriteFile(string fileLocation, List<Customer> customers)
        {
            if (File.Exists(fileLocation)) throw new ArgumentException("File already exists at " + fileLocation);
            using (var writer = new StreamWriter(fileLocation))
            {
                var columns = new List<string>
                {
                    "FirstName",
                    "LastName",
                    "Company",
                    "Address",
                    "DateOfBirth",
                    "EmailAddress",
                };
                writer.WriteLine(String.Join(",", columns));
                foreach (var customer in customers)
                {
                    var values = new List<string>
                    {
                        customer.FirstName,
                        customer.LastName,
                        customer.Company,
                        customer.Address,
                        customer.DateOfBirth.ToShortDateString(),
                        customer.EmailAddress,
                    };
                    writer.WriteLine(String.Join(",", values));
                }
                writer.Close();
            }
        }
    }
}
