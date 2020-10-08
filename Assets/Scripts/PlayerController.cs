using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float playerSpeed;
    public float jumpSpeed;

    private bool isJumping;
    private float move;
    private Rigidbody2D rb;
    // private Animator animator;
    private SpriteRenderer sprite;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Recupera o input para teclas esquerda e direita
        move = Input.GetAxisRaw("Horizontal");

        // Altera a orientação do sprite do personagem
        if (move < 0)
        {
            sprite.flipX = true;
        }
        else if (move > 0)
        {
            sprite.flipX = false;
        }

        // Move o personagem no eixo X
        rb.velocity = new Vector3(move * playerSpeed, rb.velocity.y);

        // Altera o valor do atributo "velocity" no controlador de animações para mudar a animação do personagem
        // animator.SetFloat("velocity", Mathf.Abs(rb.velocity.x));

        // Adiciona um "Impulso" no personagem para pular
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            rb.AddForce(new Vector2(rb.velocity.x, jumpSpeed), ForceMode2D.Impulse);
            isJumping = true;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }

        if (other.gameObject.CompareTag("MovingGround"))
        {
            this.transform.parent = other.transform;
            isJumping = false;
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = true;
        }

        if (other.gameObject.CompareTag("MovingGround"))
        {
            this.transform.parent = null;
            isJumping = false;
        }
    }
}
