using UnityEngine;

public class Platform : MonoBehaviour
{
    public GameObject[] obstacles;

    public GameObject[] coins;

    public float obstaclesRatio = 0.3f;

    private GameManager gameManager;
    private bool stepped = false;

    private int score = 10;

    private void Start()
    {
        GameObject findGo = GameObject.FindWithTag("GameController");
        gameManager = findGo.GetComponent<GameManager>();
    }

    private void OnEnable()
    {
        stepped = false;

        foreach (GameObject obstacle in obstacles)
        {
            obstacle.SetActive(Random.value < obstaclesRatio);
        }

        foreach (GameObject coin in coins)
        {
            coin.SetActive(true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player") && !stepped)
        {
            stepped = true;
            gameManager.Addscore(score);
        }
    }

}

