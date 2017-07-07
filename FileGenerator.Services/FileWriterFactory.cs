using System;
using FileGenerator.Core;
using FileGenerator.Services.FileWriters;

namespace FileGenerator.Services
{
    public class FileWriterFactory
    {
        public IFileWriter CreateWriter(OutputFileType type)
        {
            if (type == OutputFileType.Csv)
                return new CsvFileWriter();
            if (type == OutputFileType.Tsv)
                return new TsvFileWriter();
            throw new NotSupportedException("Don't know how to write to an output file type of " + type);
        }
    }
}
