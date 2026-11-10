using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class UiCharacterInfo : MonoBehaviour
{
    public static readonly string FormatString = "{0}: {1}";

    public Image icon;
    public TMP_Text textName;
    public TMP_Text textHp;
    public TMP_Text textAtk;
    public TMP_Text textDef;
    public TMP_Text textSpeed;

    private CharacterData data;

    public void SetEmpty()
    {
        data = null;
        textName.text = string.Empty;
        icon.sprite = null;
        textHp.text = string.Empty;
        textAtk.text = string.Empty;
        textDef.text = string.Empty;
        textSpeed.text = string.Empty;
    }

    public void SetCharacter(string id)
    {
        SetCharacter(DataTableManager.CharacterTable.Get(id));
    }
    public void OnSelectCharacter(SaveCharacterData saveData)
    {
        SetCharacter(saveData?.CharacterData);
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
        textHp.text = data.Hp.ToString();
        textAtk.text = data.Atk.ToString();
        textDef.text = data.Def.ToString();
        textSpeed.text = data.Speed.ToString();
    }
}


