using UnityEngine;

public class BackgroundLoop : MonoBehaviour
{
    public float width = 20.48f; //unity 칸의 길이
 
    private void Update() // 게임 실행 중 매 프레임마다 호출
    {
        if (transform.position.x <= -width)
        // 이 스크립트가 붙은 오브젝트의
        // X좌표가 -20.48 이하라면
        {
            transform.position += new Vector3(width * 2f, 0f, 0f);
            // 현재 위치에서 X축으로 40.96만큼 이동

        }

    }
}
