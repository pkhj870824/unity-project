using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiInventory : MonoBehaviour
{
    public readonly string[] SortingOptionNames =
    {
        "SORT_DATE_ASC",
        "SORT_DATE_DESC",
        "SORT_NAME_ASC",
        "SORT_NAME_DESC",
    };

    public readonly string[] FilteringOptionNames =
    {
        "FILTER_ALL",
        "FILTER_WEAPON",
        "FILTER_EQUIP",
        "FILTER_CONSUMABLE",
    };

    public TMP_Dropdown sorting;
    public TMP_Dropdown filtering;

    public UiItemSlotList uiItemSlotList;

    private void OnEnable()
    {
        UpdateDropdownOptions();

        OnLoad();
        OnChangeSorting(sorting.value);
        OnChangeFiltering(filtering.value);

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

        filtering.ClearOptions();
        options.Clear();
        foreach (var id in FilteringOptionNames)
        {
            options.Add(stringTable.Get(id));
        }
        filtering.AddOptions(options);
    }

    public void OnChangeSorting(int index)
    {
        uiItemSlotList.Sorting = (UiItemSlotList.SortingOptions)index;
    }

    public void OnChangeFiltering(int index)
    {
        uiItemSlotList.Filtering = (UiItemSlotList.FilteringOptions)index;
    }

    public void OnSave()
    {
        SaveLoadManager.Data.ItemList = uiItemSlotList.GetSaveItemDataList();
        SaveLoadManager.Save();
    }

    public void OnLoad()
    {
        if (SaveLoadManager.Load())
        {
            uiItemSlotList.SetSaveItemDataList(SaveLoadManager.Data.ItemList);
        }
    }

    public void OnCreateItem()
    {
        uiItemSlotList.AddRandomItem();
    }

    public void OnRemoveItem()
    {
        uiItemSlotList.RemoveItem();
    }
}
