using UnityEngine;

public class Rotater : MonoBehaviour
{
    public float rotSpeed = 360f;

    void Update()
    {
        transform.Rotate(0f, rotSpeed * Time.deltaTime, 0f);
    }
}
