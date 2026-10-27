using System;
using Unity.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("점프 기능")]
    [SerializeField]
    private Rigidbody2D rb;

    [SerializeField]
    private float jumpSpeed = 7;

    [SerializeField]
    private bool isGrounded;

    [SerializeField]
    private int jumpCount;

    [SerializeField]
    private Animator animator;

    [SerializeField]
    private AudioSource jumpSound;

    [Header("슬라이딩 기능")]
    [SerializeField]
    private AudioSource slidingSound;

    [SerializeField]
    private CircleCollider2D circle;

    [Header("사망 처리")]
    [SerializeField]
    private AudioSource dieSound;
    private GameManager gameManager;


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
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        circle = GetComponent<CircleCollider2D>();
        GameObject findGo = GameObject.FindWithTag("GameController");
        gameManager = findGo.GetComponent<GameManager>();

    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && jumpCount <= 1)
        {
            Jump();
        }
        if (Input.GetMouseButtonDown(1))
        {
            Sliding();
        }
        if (Input.GetMouseButtonUp(1))
        {
            animator.SetBool("PushKey", false);
            circle.radius = circle.radius * 2f;
            circle.offset = new Vector2(circle.offset.x, circle.offset.y / 1.5f);


        }
    }
    private void Sliding()
    {
        animator.SetBool("PushKey", true);
        slidingSound.Play();
        circle.radius = circle.radius * 0.5f;
        circle.offset = new Vector2(circle.offset.x, circle.offset.y * 1.5f);

    }

    private void Jump()
    {
        rb.linearVelocityY = jumpSpeed;
        jumpSound.Play();
        jumpCount++;
    }

    private void Die()
    {
        animator.SetTrigger("Die");
        dieSound.Play();
        rb.simulated = false;

        gameManager.OnplayerDead();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Die")
        {
            Die();
        }

        if (collision.CompareTag("Coin"))
        {
            gameManager.Addscore(1);
            collision.gameObject.SetActive(false);
        }

    }
}
