using UnityEngine;

public class ScrollingObject : MonoBehaviour
{
    public float speed = 7f;

    private void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
    }

}
