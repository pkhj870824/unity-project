using UnityEngine;
using System.IO;

public class practice2 : MonoBehaviour
{
    void Start()
    {
        string path = Path.Combine(Application.persistentDataPath, "original.txt");
        File.WriteAllText(path, "Hello Unity World");
        using (FileStream fs = new FileStream(path, FileMode.Open))
        {

        }
    }
}
