using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class ScrollingObject : MonoBehaviour
{
    public float speed = 10f;
    //이 오브젝트의 속도는 10 이다
    private GameManager gameManager;

    private void Start()
    {
        GameObject findGo = GameObject.FindWithTag("GameController");
        gameManager = findGo.GetComponent<GameManager>();
    }

    void Update()
    {
        if(gameManager.IsGameOver)
        {
            return;
        }
    //이 속도가 x좌표 -1*스피드*프레임 시간이 이동한 만큼 움직인다, 유니티 기본 축을 기본으로 하여서
        transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
    }
}
