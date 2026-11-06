using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.TextCore.Text;

public class UiCharacterButton : MonoBehaviour
{
    public Image icon;
    public TMP_Text textName;
    private CharacterData data;
    public Button button;
    public void SetEmpty()
    {
        data = null;
        icon.sprite = null;
        textName.text = string.Empty;
    }
    public void SetCharacter(string characterId)
    {
        SetCharacter(DataTableManager.characterTable.Get(characterId));
    }

    public void SetCharacter(CharacterData data)
    {
        if (data == null)
        {
            SetEmpty();
            return;
        }
        this.data = data;
        icon.sprite = data.SpriteIcon;
        textName.text = data.StringName;
    }
}
