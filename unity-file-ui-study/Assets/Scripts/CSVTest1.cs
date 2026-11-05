using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using CsvHelper;
using System.IO;
using System.Globalization;

public class CsvData
{
    public string Id { get; set; }
    public string String { get; set; }
}
public class CSVTest1 : MonoBehaviour
{

    private StringTable stringTable;
    private void Start()
    {
        stringTable = new StringTable();
        stringTable.Load("StringTableKR");

        Debug.Log(stringTable.Get("HI"));
        Debug.Log(stringTable.Get("BYE"));
        Debug.Log(stringTable.Get("DIE"));

    }
    // public TextAsset textAsset;
    // private void Start()
    // {
    //     TextAsset csv = Resources.Load<TextAsset>("DataTables/StringTableKR");

    //     using (var reader = new StringReader(csv.text))
    //     using (var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture))
    //     {
    //         var records =  csvReader.GetRecords<CsvData>();
    //         foreach(CsvData record in records)
    //         {
    //             Debug.Log($"{record.Id} : {record.String}");
    //         }
    //     }
    // }

}
