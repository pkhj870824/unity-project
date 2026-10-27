using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.Events;

public class Coin : MonoBehaviour, IItem

{
    private GameManager gameManager;
    public UnityEvent OnUse { get; set; } = new UnityEvent();

    int score = 100;
    private void Start()
    {
        GameObject findGo = GameObject.FindWithTag("GameController");
        gameManager = findGo.GetComponent<GameManager>();
    }
    public void Use(GameObject target)
    {
        gameManager.AddScore(score);
        gameObject.SetActive(false);
        OnUse.Invoke();
    }
}