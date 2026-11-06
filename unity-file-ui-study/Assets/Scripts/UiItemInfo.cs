
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiItemInfo : MonoBehaviour
{
    public TMP_Text textName;
    public Image icon;
    public TMP_Text textType;
    public TMP_Text textCost;
    public TMP_Text textValue;
    public TMP_Text textDesc;

    private ItemData data;
    public void SetEmpty()
    {
        data = null;
        textName.text = string.Empty;
        icon.sprite = null;
        textType.text = string.Empty;
        textCost.text = string.Empty;
        textValue.text = string.Empty;
        textDesc.text = string.Empty;

    }
    public void SetItem(string id)
    {
        SetItem(DataTableManager.itemTable.Get(id));
    }
    public void SetItem(ItemData data)
    {
        if (data == null)
        {
            SetEmpty();
            return;
        }
        this.data = data;

        textName.text = data.StringName;
        icon.sprite = data.spriteIcon;
        textType.text = data.Type.ToString();
        textCost.text = data.Cost.ToString();
        textValue.text = data.Value.ToString();
        textDesc.text = data.StringDesc;
    }
}
