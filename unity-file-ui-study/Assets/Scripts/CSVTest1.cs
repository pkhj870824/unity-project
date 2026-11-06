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

    public UiCharacterButton[] charButtons;
    public UiCharacterInfo charInfo;
    private void Start()
    {
        charButtons[0].SetCharacter("CHAR_1");
        charButtons[0].button.onClick.AddListener(() => charInfo.SetCharacter("CHAR_1"));
        charButtons[1].SetCharacter("CHAR_2");
        charButtons[1].button.onClick.AddListener(() => charInfo.SetCharacter("CHAR_2"));
        charButtons[2].SetCharacter("CHAR_3");
        charButtons[2].button.onClick.AddListener(() => charInfo.SetCharacter("CHAR_3"));
        charButtons[3].SetCharacter("CHAR_4");
        charButtons[3].button.onClick.AddListener(() => charInfo.SetCharacter("CHAR_4"));
    }
    // public UiItemButton[] itemButtons;
    // public UiItemInfo itemInfo;
    // private void Start()
    // {
    //     itemButtons[0].SetItem("ITEM_1");
    //     itemButtons[0].button.onClick.AddListener(() => itemInfo.SetItem("ITEM_1"));
    //     itemButtons[1].SetItem("ITEM_2");
    //     itemButtons[1].button.onClick.AddListener(() => itemInfo.SetItem("ITEM_2"));
    //     itemButtons[2].SetItem("ITEM_3");
    //     itemButtons[2].button.onClick.AddListener(() => itemInfo.SetItem("ITEM_3"));
    //     itemButtons[3].SetItem("ITEM_4");
    //     itemButtons[3].button.onClick.AddListener(() => itemInfo.SetItem("ITEM_4"));
    }
    // private void Update()
    // {
    //     if(Input.GetKeyDown(KeyCode.Alpha1))
    //     {
    //         itemButton.SetEmpty();
    //     }
    //             if(Input.GetKeyDown(KeyCode.Alpha1))
    //     {
    //         itemButton.SetItem("ITEM_1");
    //     }
    //             if(Input.GetKeyDown(KeyCode.Alpha2))
    //     {
    //         itemButton.SetItem("ITEM_2");
    //     }
    // }

    // private void Start()
    // {
    //     stringTable = DataTableManager.StringTable;


    //     Debug.Log(stringTable.Get("HELLO"));
    //     Debug.Log(stringTable.Get("BYE"));
    //     Debug.Log(stringTable.Get("YOU_DIE"));

    //     var ItemData = DataTableManager.itemTable.Get("ITEM_1");
    //     Debug.Log($"{ItemData.StringName},{ItemData.StringDesc}");

    // }
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

