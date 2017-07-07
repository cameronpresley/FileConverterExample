using System.Collections.Generic;
using FileGenerator.Core;

namespace FileGenerator.Services.FileWriters
{
    public interface IFileWriter
    {
        void WriteFile(string filePath, List<Customer> customers);
    }
}
