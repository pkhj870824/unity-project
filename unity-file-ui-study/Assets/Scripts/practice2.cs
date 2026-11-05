using UnityEngine;
using System.IO;

public class practice2 : MonoBehaviour
{
    private const byte key = 0xAB;
    private string folder;
    private string srcPath;
    private string encPath;
    private string decPath;
    void Start()
    {
        folder = Path.Combine(Application.persistentDataPath, "Secret");
        if (Directory.Exists(folder))
        {
            Directory.CreateDirectory(folder);
        }


        srcPath = Path.Combine(folder, "original.txt");
        encPath = Path.Combine(folder, "encrypted.txt");
        decPath = Path.Combine(folder, "decrypted.txt");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Start();
            WriteOriginal();
        }
    }

    private void WriteOriginal()
    {
        File.WriteAllText(srcPath, "Hello Unity world!!");
    }

    private void Encrypt()
    {
        using (Stream input = new FileStream(srcPath, FileMode.Open))
        using (Stream output = new FileStream(encPath, FileMode.Create))
        {
            int b;
            while ((b = input.ReadByte()) != -1)
            {
                output.WriteByte((byte)(b ^ key));
            }
        }
    }
    private void Decrypt()
    {
        using (Stream input = new FileStream(encPath, FileMode.Open))
        using (Stream output = new FileStream(decPath, FileMode.Create))
        {
            int b;
            while ((b = input.ReadByte()) != -1)
            {
                output.WriteByte((byte)(b ^ key));
            }
        }
        string result = File.ReadAllText(decPath);
        bool equal = result == File.ReadAllText(srcPath);
    }
}
