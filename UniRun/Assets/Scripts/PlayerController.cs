using System;
using System.Security;
using Unity.VisualScripting;
using UnityEngine;

//1. 점프뛰기 : 위로 속도를 가지게 한다. => Rigidbody 속도를 설정한다.
//2. 애니메이션 제어 : 
//3. 사망 처리 


public class PlayerController : MonoBehaviour
{
    [Header("점프 기능")]

    //어트리뷰트 : 기능에 영향을 주지않고 쓸때 편하기 위해 만들어둔 것 ex) header, serializefield,
    //[SerializeField] : 외부에 공개 X / 밖에서 수정 불가능 / 유니티에서 수정 가능
    //private : 외부에 공개 x / 밖, 유니티에서 수정 불가능
    //public : 외부에 공개 o / 밖 유니티에서 수정 가능
    [SerializeField] Rigidbody2D rb;
    [SerializeField][Range(0, 20f)] float jumpSpeed;
    [SerializeField] AudioSource jumpsound;
    [SerializeField] bool isGrounded;
    [SerializeField] int jumpCount;

    [Header("애니메이션")]
    [SerializeField] Animator animator;

    [Header("게임 오버")]
    [SerializeField] AudioSource dieSound;
    [SerializeField] bool isDead;

    // Awake 함수는 Start 함수보다 먼저 호출됨
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump") && jumpCount <= 1 && !isDead)
        {
            Jump();
        }
    }

    public void Die()
    {
        if (isDead)
        {
            return;
        }
        isDead = true;

        animator.SetTrigger("Die");
        rb.linearVelocity = Vector2.zero;
        //바닥에 떨어져서 멈춰서 죽는걸 원할때 rb.simulated = false;
        dieSound.Play();
    }
    private void Jump()
    {
        rb.linearVelocityY = jumpSpeed;
        jumpsound.Play();
        jumpCount++;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Platform")
        {
            isGrounded = true;
            jumpCount = 0;
            animator.SetBool("Grounded", true);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Platform")
        {
            isGrounded = false;
            animator.SetBool("Grounded", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Dead")
        {
            Die();
        }

    }
}
