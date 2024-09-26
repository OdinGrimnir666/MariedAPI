using System.Globalization;
using Core.Models;
using CsvHelper;
using Infrastructure.Intefaces;


namespace Infrastructure.Services;

public class CSVReader<T> : ICSVReader<T>
{
    public List<T> Read(StreamReader reader)
    {
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            var records = csv.GetRecords<T>().ToList();
            return records;
        }
    }
}