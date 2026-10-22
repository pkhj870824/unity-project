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

    [SerializeField] 
    private Rigidbody2D rb;

    [SerializeField][Range(0, 20f)] 
    private float jumpSpeed;

    [SerializeField] 
    private AudioSource jumpsound;

    [SerializeField] 
    private bool isGrounded;

    [SerializeField] 
    private int jumpCount;

    [Header("애니메이션")]

    [SerializeField] 
    private Animator animator;

    [Header("게임 오버")]

    [SerializeField] 
    private AudioSource dieSound;
    
    private GameManager gameManager;
    
    [SerializeField] 
    private bool isDead;

    // Awake 함수는 Start 함수보다 먼저 호출됨
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        GameObject findGo = GameObject.FindWithTag("GameController");
        gameManager = findGo.GetComponent<GameManager>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && jumpCount <= 1 && !isDead)
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

        gameManager.OnPlayerDead();
    }
    private void Jump()
    {
        rb.linearVelocityY = jumpSpeed;
        jumpsound.Play();
        jumpCount++;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Platform" && 
        collision.contacts[0].normal.y > 0.7f)
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
