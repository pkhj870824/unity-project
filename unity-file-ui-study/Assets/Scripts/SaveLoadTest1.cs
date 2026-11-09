using UnityEngine;
using UnityEngine.UIElements;

public class SaveLoadTest1 : MonoBehaviour
{
    public void Save()
    {
        string[] playerName = "JunHyun Park".Split(" ");

        SaveLoadManager.Data = new SaveDatav4();
        SaveLoadManager.Data.firstName = playerName[0];
        SaveLoadManager.Data.lastName = playerName[1];
        SaveLoadManager.Data.Gold = Random.Range(100, 200);
        Debug.Log($"세이브 결과: {SaveLoadManager.Save()}");
    }
    public void Load()
    {
        Debug.Log($"로드 결과: {SaveLoadManager.Load()}");
        Debug.Log(SaveLoadManager.Data.firstName);
        Debug.Log(SaveLoadManager.Data.lastName);
        Debug.Log(SaveLoadManager.Data.Gold);
    }
}
