using UnityEngine;
using UnityEngine.InputSystem;

public abstract class SaveData
{
    public int Version { get; protected set; }
    public abstract SaveData Versionup();
}

public class SaveDatav4 : SaveData
{
    public string firstName { get; set; } = string.Empty;
    public string lastName { get; set; } = string.Empty;

    public int Gold { get; set; } = 100;
    public SaveDatav4()
    {
        Version = 4;
    }
    public override SaveData Versionup()
    {
        throw new System.NotImplementedException();
    }
}
public class SaveDatav3 : SaveData
{
    public string playerName { get; set; } = string.Empty;
    public int Gold { get; set; } = 100;
    public int Exp { get; set; } = 50;
    public SaveDatav3()
    {
        Version = 3;
    }
    public override SaveData Versionup()
    {
        var data = new SaveDatav4();

        string[] names = playerName.Split(' ');
        data.firstName = names[0];
        data.lastName = names[1];
        data.Gold = Gold;

        return data;
    }
}
public class SaveDatav2 : SaveData
{
    public string playerName { get; set; } = string.Empty;
    public int Gold { get; set; } = 100;
    public SaveDatav2()
    {
        Version = 2;
    }
    public override SaveData Versionup()
    {
        var data = new SaveDatav3();
        data.playerName = playerName;
        data.Gold = Gold;
        return data;
    }
}

public class SaveDatav1 : SaveData
{
    public string playerName { get; set; } = string.Empty;
    public SaveDatav1()
    {
        Version = 1;
    }
    public override SaveData Versionup()
    {
        var data = new SaveDatav2();
        data.playerName = playerName;
        return data;
    }
}
