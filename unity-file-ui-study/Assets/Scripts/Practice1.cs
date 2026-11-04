using UnityEngine;
using System.IO;
using UnityEngine.UIElements;
using UnityEngine.Rendering;

public class Practice1 : MonoBehaviour
{
    void Start()
    {
        string saveDir = Path.Combine(Application.persistentDataPath, "SaveData");
        if (!Directory.Exists(saveDir))
        {
            Directory.CreateDirectory(saveDir);
        }

        int savetime = 3;
        int level = 0;

        for (int i = 0; i < savetime; i++)
        {
            level += 10;
            string filePath = Path.Combine(saveDir, $"save{i + 1}.txt");
            if (!File.Exists(filePath))
            {
                File.WriteAllText(filePath, $"플레이어 레벨: {level}");
            }
        }

        string[] files = Directory.GetFiles(saveDir);

        Debug.Log("=== 세이브 파일 목록 ===");
        for (int i = 0; i < files.Length; i++)
        {
            string name = Path.GetFileName(files[i]);
            string extension = Path.GetExtension(files[i]);
            Debug.Log($"- {name} ({extension})");
        }
        string sourcePath = Path.Combine(saveDir, "save1.txt");
        string backupPath = Path.Combine(saveDir, "save1_backup.txt");
        if (!File.Exists(backupPath))
        {
            File.Copy(sourcePath, backupPath);
            Debug.Log($"{sourcePath} -> {backupPath} 복사 완료");

        }
        else if (File.Exists(backupPath))
        {
            Debug.Log("파일이 존재합니다");
        }

        string deletePath = Path.Combine(saveDir, "save3.txt");


        if (File.Exists(deletePath))
        {
            File.Delete(deletePath);
            Debug.Log($"{deletePath}삭제 완료");
        }
        else if (!File.Exists(deletePath))
        {
            Debug.Log("파일이 이미 삭제 되었습니다");
        }

        files = Directory.GetFiles(saveDir);
        Debug.Log("=== 작업 후 파일 목록 ===");
        
        for (int i = 0; i < files.Length; i++)
        {
            string name = Path.GetFileName(files[i]);
            string extension = Path.GetExtension(files[i]);
            Debug.Log($"- {name} ({extension})");
        }

    }
}

