using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using TMPro;
using UnityEngine;
public class UiCharacter : MonoBehaviour
{
    public readonly string[] SortingOptionNames =
    {
        "SORT_DATE_ASC",
        "SORT_DATE_DESC",
        "SORT_NAME_ASC",
        "SORT_NAME_DESC",
    };

    public TMP_Dropdown sorting;

    public UiCharacterSlotList uiCharacterSlotList;

    private void OnEnable()
    {
        UpdateDropdownOptions();

        OnLoad();
        OnChangeSorting(sorting.value);

        Variables.OnLanguageChanged += UpdateDropdownOptions;
    }

    private void OnDisable()
    {
        Variables.OnLanguageChanged -= UpdateDropdownOptions;
        OnSave();
    }

    public void UpdateDropdownOptions()
    {
        var stringTable = DataTableManager.StringTable;
        sorting.ClearOptions();
        var options = new List<string>();
        foreach (var id in SortingOptionNames)
        {
            options.Add(stringTable.Get(id));
        }
        sorting.AddOptions(options);
    }

    public void OnChangeSorting(int index)
    {
        uiCharacterSlotList.Sorting = (UiCharacterSlotList.SortingOptions)index;
    }

    public void OnSave()
    {
        SaveLoadManager.Data.CharacterList = uiCharacterSlotList.GetSaveCharacterDataList();
        SaveLoadManager.Save();
    }

    public void OnLoad()
    {
        if (SaveLoadManager.Load())
        {
            uiCharacterSlotList.SetSaveCharacterDataList(SaveLoadManager.Data.CharacterList);
        }
    }

    public void OnCreateCharacter()
    {
        uiCharacterSlotList.AddRandomCharacter();
    }

    public void OnRemoveCharacter()
    {
        uiCharacterSlotList.RemoveCharacter();
    }
}
