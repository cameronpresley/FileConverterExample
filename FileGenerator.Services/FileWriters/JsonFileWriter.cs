using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using FileGenerator.Core;
using Newtonsoft.Json.Linq;

namespace FileGenerator.Services.FileWriters
{
    public class JsonFileWriter : IFileWriter
    {
        public void WriteFile(string filePath, List<Customer> customers)
        {
            var jObjects = customers.Select(x => new JObject
            {
                new JProperty("first-name", x.FirstName),
                new JProperty("last-name", x.LastName),
                new JProperty("date-of-birth", x.DateOfBirth.ToShortDateString()),
                new JProperty("email-address", x.EmailAddress),
                new JProperty("company", x.Company),
                new JProperty("physical-address", x.Address),
            });
            using (var writer = new StreamWriter(filePath))
            {
                writer.Write(new JObject(new JProperty("customers", jObjects)).ToString());
                writer.Close();
                
            }
        }
    }
}
