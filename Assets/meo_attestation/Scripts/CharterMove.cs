using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CharterMove : MonoBehaviour
{
    [SerializeField][Range(5,20)] private float movementSpeed = 12f;
    private float horizontalMovement;

    private Rigidbody2D rB;

    [SerializeField][Range(5,20)] private float jumpForce = 20f;
    private bool justJumped = false;

    [HideInInspector] public bool onGround = false;
    [SerializeField] private bool mIsAnim = true;
    private Animator animator;
    [SerializeField] private TextMeshProUGUI ScoreText;
    private int score = 0;
    [Space]
    [SerializeField] private float MaxHp = 100f;
    [SerializeField] private float EnemyDamage = 10f;
    [SerializeField] private TextMeshProUGUI HpText;
    private float currentHp;

    private void Start()
    {
        rB = GetComponent<Rigidbody2D>();
        currentHp = MaxHp;
        HpText.text = $"HP: {(int)currentHp}";
        if (mIsAnim)
            animator = GetComponent<Animator>();
    }

    private void Update()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal");

        if (!justJumped && Input.GetKeyDown(KeyCode.Space) && onGround)
            justJumped = true;

        if (mIsAnim)
            animator.SetFloat("Horizontal", rB.velocity.x);
    }

    private void FixedUpdate()
    {
        rB.velocity = new Vector2(horizontalMovement * movementSpeed, rB.velocity.y);

        if (justJumped)
        {
            justJumped = false;
            rB.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (currentHp - EnemyDamage > 0)
                currentHp -= EnemyDamage;
            HpText.text = $"HP: {(int)currentHp}";
            Destroy(collision.gameObject);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            onGround = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            onGround = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Coin")
        {
            score++;
            ScoreText.text = $"Score: {score}";
            Destroy(collision.gameObject);
        }
    }
}
