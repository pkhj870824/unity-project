using System;
using System.Collections.Generic;
using UnityEngine;
using CsvHelper;
using System.IO;
using System.Globalization;
using System.Linq;

public abstract class DataTable
{
    public static readonly string FormatPath = "DataTables/{0}";


    public abstract void Load(string filename);

    public static List<T> LoadCSV<T>(String csvText)
    {
        using (var reader = new StringReader(csvText))
        using (var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            var records = csvReader.GetRecords<T>();
            return records.ToList();
        }
    }
}
