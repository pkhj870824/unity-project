using TMPro;
using Unity.VisualScripting;

public enum Languages
{
    Korean,
    English,
    Japanese,
}

public static class DataTableIds
{
    public static readonly string[] StringTableIds =
    {
        "StringTableKR",
        "StringTableEN",
        "StringTableJP",
    };

    public static string String => StringTableIds[(int)Variables.Language];
    public static readonly string item = "ItemTable";
    public static readonly string character = "CharacterTable";
}
public static class Variables
{
    public static event System.Action OnLanguageChanged;
    private static Languages language = Languages.Korean;

    public static Languages Language
    {
        get => language;
        set
        {
            if (language == value)
            {
                return;
            }
            language = value;

            DataTableManager.ChangedLanguage(language);
            OnLanguageChanged?.Invoke();
        }
    }
}

