using UnityEngine;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Unity.VisualScripting;


[Serializable]
public class ObjectSaveData
{
    public string prefabName;
    public Vector3 position;
    public Quaternion rotation;
    public Vector3 scale;
    public Color color;
}

public class JasonObject : MonoBehaviour
{
    public GameObject[] prefabs;
    private List<GameObject> objects = new List<GameObject>();
    public JsonSerializerSettings jsonSettings;

    private void Awake()
    {
        jsonSettings = new JsonSerializerSettings();
        jsonSettings.Formatting = Formatting.Indented;
        jsonSettings.Converters.Add(new Vector3Converter());
        jsonSettings.Converters.Add(new ColorConverter());
        jsonSettings.Converters.Add(new QuaternionConverter());

    }
    public void Create()
    {

        int randomIndex = UnityEngine.Random.Range(0, prefabs.Length);
        Vector3 randomPosition = UnityEngine.Random.insideUnitSphere * 10f;
        Quaternion randomRotation = UnityEngine.Random.rotation;
        Vector3 randomScale = Vector3.one * UnityEngine.Random.Range(0.5f, 2f);
        Color randomColor = UnityEngine.Random.ColorHSV();

        GameObject newGo = Instantiate(prefabs[randomIndex]);
        newGo.transform.position = randomPosition;
        newGo.transform.rotation = randomRotation;
        newGo.transform.localScale = randomScale;
        newGo.GetComponent<Renderer>().material.color = randomColor;

        objects.Add(newGo);
    }
    public void Clear()
    {
        Debug.Log("호출");
        foreach (GameObject obj in objects)
        {
            Destroy(obj);
        }
        objects.Clear();

    }
    public void Save()
    {
        List<ObjectSaveData> saveDatas = new List<ObjectSaveData>();
        foreach (GameObject obj in objects)
        {
            ObjectSaveData data = new ObjectSaveData();
            data.prefabName = obj.name;
            data.position = obj.transform.position;
            data.rotation = obj.transform.rotation;
            data.scale = obj.transform.localScale;
            data.color = obj.GetComponent<Renderer>().material.color;
            saveDatas.Add(data);
        }
        string json = JsonConvert.SerializeObject(
        saveDatas,
        Formatting.Indented,
        jsonSettings
        );
        string path = Path.Combine(Application.persistentDataPath, "JasonObject.json");
        Debug.Log(path);
        File.WriteAllText(path, json);
    }

    public void Load()
    {
        Clear();

        string path = Path.Combine(Application.persistentDataPath, "JasonObject.json");
        string json = File.ReadAllText(path);

        List<ObjectSaveData> saveDatas = JsonConvert.DeserializeObject<List<ObjectSaveData>>(
        json,
        jsonSettings);
        foreach (var data in saveDatas)
        {
            int prefabIndex = -1;
            for (int i = 0; i < prefabs.Length; ++i)
            {
                if (data.prefabName.Contains(prefabs[i].name))
                {
                    prefabIndex = i;
                    break;
                }
            }
            var newGo = Instantiate(prefabs[prefabIndex]);
            newGo.transform.position = data.position;
            newGo.transform.rotation = data.rotation;
            newGo.transform.localScale = data.scale;
            newGo.GetComponent<Renderer>().material.color = data.color;

            objects.Add(newGo);

        }
    }
}
