using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class ScrollingObject : MonoBehaviour
{
    public float speed = 10f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
    }
}
