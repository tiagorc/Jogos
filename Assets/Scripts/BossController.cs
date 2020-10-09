using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public float playerSpeed;
    public float jumpForce;

    private float move;
    private bool isJumping;
    private bool isDead;
    private Animator animator;
    private SpriteRenderer sprite;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        //recuperando os componentes
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead) return;

        //pode ser -1, 0, 1
        move = Input.GetAxisRaw("Horizontal");

        //altera a orientação do player
        if (move < 0)
        {
            sprite.flipX = true;
        }
        else if (move > 0)
        {
            sprite.flipX = false;
        }

        //move o personagem no eixo x
        rb.velocity = new Vector3(move * playerSpeed, rb.velocity.y);

        //altera o valor do atributo velocity no controlador de animações para mudar a animação do personagem
        animator.SetFloat("velocity", Mathf.Abs(rb.velocity.x));

        //adiciona um impulso no personagem para pular
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            rb.AddForce(new Vector2(rb.velocity.x, jumpForce), ForceMode2D.Impulse);
            isJumping = true;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }

        if (other.gameObject.CompareTag("KillerGround"))
        {
            isDead = true;
            animator.SetBool("isDead", isDead);
        }

        if (other.gameObject.CompareTag("MovingGround"))
        {
            this.transform.parent = other.transform;
            isJumping = false;
        }

    }
}
