using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public UiManager uiManager;

    public ZombieSpawner zombieSpawner;
    public ItemSpawner itemSpawner;
    private int score = 0;
    public bool isGameOver { get; private set; }

    private void Start()
    {
        uiManager.SetScore(score);
        uiManager.SetActiveGameOverUI(false);

    }
    public void AddScore(int add)
    {
        if (isGameOver)
        {
            return;
        }

        score += add;
        uiManager.SetScore(score);
    }
    public void EndGame()
    {
        isGameOver = true;
        uiManager.SetActiveGameOverUI(true);

        itemSpawner.enabled = false;
        zombieSpawner.onEndGame();
        itemSpawner.enabled = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Game");
    }
}
