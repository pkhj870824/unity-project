using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiItemSlot : MonoBehaviour
{
    public int SlotIndex { get; set; } = -1;

    public Button button;

    public Image icon;
    public TMP_Text textItemName;

    public SaveItemData ItemData { get; private set; }

    public void SetEmpty()
    {
        ItemData = null;
        icon.sprite = null;
        textItemName.text = string.Empty;
    }

    public void SetItem(SaveItemData data)
    {
        ItemData = data;
        icon.sprite = ItemData.ItemData.SpriteIcon;
        textItemName.text = ItemData.ItemData.StringName;
    }
}
