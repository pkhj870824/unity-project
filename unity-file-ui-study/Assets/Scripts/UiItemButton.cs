using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UiItemButton : MonoBehaviour
{
    public Image icon;
    public TMP_Text textName;
    private ItemData data;
    public Button button;
    public void SetEmpty()
    {
        data = null;
        icon.sprite = null;
        textName.text = string.Empty;
    }
    public void SetItem(string itemId)
    {
        SetItem(DataTableManager.itemTable.Get(itemId));
    }
    public void SetItem(ItemData data)
    {
        if (data == null)
        {
            SetEmpty();
            return;
        }
        this.data = data;
        icon.sprite = data.spriteIcon;
        textName.text = data.StringName;

    }
}
