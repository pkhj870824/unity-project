using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{

    public GameObject bulletPrefab;
    private Transform target;
    public float interval = 1f;
    private float timer = 0;

    private void Start()
    {
        GameObject findGo = GameObject.FindWithTag("Player");
        target = findGo.transform;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > interval)
        {
            timer = 0f;
            Spawn();
        }
    }

    private void Spawn()
    {
        Vector3 position = transform.position;
        Vector3 direction = target.position - transform.position;
        direction.Normalize();
        Quaternion rotation = Quaternion.LookRotation(direction);
        Instantiate(bulletPrefab, position, rotation);
    }
}
