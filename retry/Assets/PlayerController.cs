using JetBrains.Annotations;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed = 10f;

    private Rigidbody rb;
    private GameManager gameManager;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        GameObject findGo = GameObject.FindWithTag("GameController");
        gameManager = findGo.GetComponent<GameManager>();
    }

    private void Update()
    {
        Vector3 direction = Vector3.zero;
        direction.x = Input.GetAxisRaw("Horizontal");
        direction.z = Input.GetAxisRaw("Vertical");

        Debug.Log(direction.x);

        if (direction.magnitude > 1f)
        {
            direction.Normalize();
        }
        rb.linearVelocity = direction * speed;
    }

    public void OnDie()
    {
        gameObject.SetActive(false);
        gameManager.EndGame();
    }
}
