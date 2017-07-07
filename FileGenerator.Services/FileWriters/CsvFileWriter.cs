using System;
using System.Collections.Generic;
using System.IO;
using FileGenerator.Core;

namespace FileGenerator.Services.FileWriters
{
    public class CsvFileWriter : IFileWriter
    {
        public void WriteFile(string fileLocation, List<Customer> customers)
        {
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
