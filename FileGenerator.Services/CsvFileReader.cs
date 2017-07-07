using System;
using System.Collections.Generic;
using System.Linq;
using FileGenerator.Core;

namespace FileGenerator.Services
{
    public class CsvFileReader
    {
        private const string IdColumn = "id";
        private const string FirstNameColumn = "first_name";
        private const string LastNameColumn = "last_name";
        private const string EmailColumn = "email";
        private const string AddressColumn = "address";
        private const string CompanyColumn = "company";
        private const string DobColumn = "dob";

        public List<Customer> RetrieveRecords(string fileContents)
        {
            var lines = fileContents.Split(new[] {'\n'}, StringSplitOptions.RemoveEmptyEntries).ToList();

            var columns = lines.First().Split(new []{","}, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToList();
            return lines.Skip(1)
                .Select(line => line.Split(','))
                .Select(pieces => new Customer
                {
                    FirstName = pieces[columns.FindIndex(x => x == FirstNameColumn)],
                    LastName = pieces[columns.FindIndex(x => x == LastNameColumn)],
                    Company = pieces[columns.FindIndex(x => x == CompanyColumn)],
                    DateOfBirth = DateTime.Parse(pieces[columns.FindIndex(x => x == DobColumn)]),
                    EmailAddress = pieces[columns.FindIndex(x => x == EmailColumn)],
                    Address = pieces[columns.FindIndex(x => x == AddressColumn)],
                })
                .ToList();
        }
    }
}
