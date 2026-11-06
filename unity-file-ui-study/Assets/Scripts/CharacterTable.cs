using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CharacterTable : DataTable
{
    private readonly Dictionary<string, CharacterData> table = new Dictionary<string, CharacterData>();

    public override void Load(string filename)
    {
        table.Clear();

        var path = string.Format(FormatPath, filename);
        var textAsset = Resources.Load<TextAsset>(path);
        var list = LoadCSV<CharacterData>(textAsset.text);
        foreach(var character in list)
        {
            if(!table.ContainsKey(character.Id))
            {
                table.Add(character.Id, character);
            }

            else
            {
                Debug.LogError("캐릭터 아이디 중복");
            }
        
        }
    }
    public CharacterData Get(string id)
    {
        if(!table.ContainsKey(id))
        {
            Debug.LogError($"{id}: 캐릭터 없음");
            return null;
        }
        return table[id];
    }

    public CharacterData GetRandom()
    {
        var characterList = table.Values.ToList();
        return characterList[Random.Range(0, characterList.Count)];
    }
}
