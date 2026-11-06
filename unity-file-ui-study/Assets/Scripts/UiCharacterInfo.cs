using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiCharacterInfo : MonoBehaviour
{
    public TMP_Text textName;
    public Image icon;
    public TMP_Text textHp;
    public TMP_Text textAttack;
    public TMP_Text textDefence;
    public TMP_Text textSpeed;

    private CharacterData data;
    public void SetEmpty()
    {
        data = null;
        textName.text = string.Empty;
        icon.sprite = null;
        textHp.text = string.Empty;
        textAttack.text = string.Empty;
        textDefence.text = string.Empty;
        textSpeed.text = string.Empty;
    }
    public void SetCharacter(string id)
    {
        SetCharacter(DataTableManager.characterTable.Get(id));
    }
    public void SetCharacter(CharacterData data)
    {
        if (data == null)
        {
            SetEmpty();
            return;
        }
        this.data = data;

        textName.text = data.StringName;
        icon.sprite = data.SpriteIcon;
        textHp.text = $"HP: {data.Hp}";
        textAttack.text = $"ATK: {data.Atk}";
        textDefence.text = $"DEF: {data.Def}";
        textSpeed.text = $"SPEED: {data.Speed}";
    }
}
