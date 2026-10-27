using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

using UnityEngine.UIElements;
using System.Collections.Generic;

public class ItemSpawner : MonoBehaviour
{
    public GameObject[] itemPrefabs;
    private List<GameObject>[] itemPool;
    public float minX = -10f;
    public float maxX = 10f;
    public float minZ = -10f;
    public float maxZ = 10f;
    public float spawnInterval = 10f;
    private float spawnTimer;

    //public Transform spawnCenter;
    //public float spawnRange;
    private void Awake()
    {
        itemPool = new List<GameObject>[itemPrefabs.Length];
        for (int i = 0; i < itemPool.Length; ++i)
        {
            itemPool[i] = new List<GameObject>();
        }
    }
    private void Update()
    {
        spawnTimer += Time.deltaTime;

        if (spawnTimer >= spawnInterval)
        {
            spawnTimer = 0f;

            int index = Random.Range(0, itemPrefabs.Length);
            if (itemPool[index].Count == 0)
            {
                GameObject newItemGo = Instantiate(itemPrefabs[index]);
                itemPool[index].Add(newItemGo);

                newItemGo.SetActive(false);
                IItem newItem = newItemGo.GetComponent<IItem>();

                if (newItem != null)
                {
                    newItem.OnUse.AddListener(() => itemPool[index].Add(newItemGo));
                }
            }

            Vector3 position = Vector3.zero;
            position.y = 0.5f;
            position.x = Random.Range(minX, maxX);
            position.z = Random.Range(minZ, maxZ);

            if (NavMesh.SamplePosition(position, out NavMeshHit hit, 10f, NavMesh.AllAreas))
            {
                position = hit.position;
                position.y = 0.5f;

                GameObject newGo = itemPool[index][0];
                newGo.transform.position = position;
                newGo.SetActive(true);

                itemPool[index].RemoveAt(0);
            }
            else
            {
                Debug.Log("생성 실패");
            }
        }
    }


    //private void CreateItem()
    // {
    //     int index = Random.Range(0, itemPrefabs.Length);
    //float x = Random.Range(-spawnRange, spawnRange);
    //float z = Random.Range(-spawnRange, spawnRange);
    // Vector3 spawnPosition = new Vector3(spawnCenter.position.x + x, 0, spawnCenter.position.z + z);

    // if (NavMesh.SamplePosition(spawnPosition, out NavMeshHit hit, 2f, NavMesh.AllAreas))
    // {
    //     Instantiate(itemPrefabs[index], hit.position, Quaternion.identity);

    // }
    //}

}
