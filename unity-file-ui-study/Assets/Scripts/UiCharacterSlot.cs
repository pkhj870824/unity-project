using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiCharacterSlot : MonoBehaviour
{
    public int SlotIndex { get; set; } = -1;
    public Button button;
    public Image icon;
    public TMP_Text textCharacterName;

    public SaveCharacterData CharacterData { get; private set; }
    public void SetEmpty()
    {
        CharacterData = null;
        icon.sprite = null;
        textCharacterName.text = string.Empty;
    }

    public void SetCharacter(SaveCharacterData data)
    {
        CharacterData = data;
        icon.sprite = CharacterData.CharacterData.SpriteIcon;
        textCharacterName.text = CharacterData.CharacterData.StringName;
    }
}
