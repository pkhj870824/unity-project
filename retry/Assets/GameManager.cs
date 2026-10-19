using NUnit.Framework;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool isGameOver;

    public TextMeshProUGUI timeText;
    public GameObject gameOverUI;
    public TextMeshProUGUI recordText;
    private float survivorTime;

    private void Start()
    {
        survivorTime = 0f;
        isGameOver = false;
        gameOverUI.SetActive(false);
    }
    private void Update()
    {
        if (!isGameOver)
        {
            survivorTime += Time.deltaTime;
            timeText.text = $"Time: {survivorTime:F1}";
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("Game");
            }
        }
    }

    public void EndGame()
    {
        isGameOver = true;

        gameOverUI.SetActive(true);
        float bestScore = PlayerPrefs.GetFloat("BestTime");
        if (survivorTime > bestScore)
        {
            bestScore = survivorTime;
            PlayerPrefs.SetFloat("BestTime", bestScore);
        }
        recordText.text = $"Best Record: {bestScore:F1}";
    }
}
