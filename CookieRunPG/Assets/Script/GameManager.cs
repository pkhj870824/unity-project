using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static readonly string formatScore = "SCORE: {0}";

    public TMP_Text scoreText;
    public GameObject gameooverUI;
    public Image hpImage;

    public bool IsGameOver { get; private set; }

    private int score = 0;
    private float hp = 100f;
    private float decreaseSpeed = 5f;

    private void Start()
    {
        gameooverUI.SetActive(false);
    }

    private void Update()
    {
        if (IsGameOver && Input.GetMouseButtonDown(0))
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }

    if (!IsGameOver)
    {
        hp -= Time.deltaTime * decreaseSpeed;
        hp = Mathf.Clamp(hp, 0f, 100f);

        hpImage.fillAmount = hp / 100f;
    }
    }

    public void SetScore(int score)
    {
        this.score = score;
        scoreText.text = string.Format(formatScore, score);
    }

    public void Addscore(int add)
    {
        if (IsGameOver)
        {
            return;
        }

        SetScore(score + add);

    }

    public void OnplayerDead()
    {
        IsGameOver = true;
        gameooverUI.SetActive(true);

    }
}
