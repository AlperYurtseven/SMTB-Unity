using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public Rigidbody2D rb;
    public float vertical_speed;
    public float horizontal_speed;
    public float max_jump_height;
    public float max_horizontal_speed;

    GameManager gameManager;

    public bool isGrounded;
    public float initialJumpHeight;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isGrounded = true;
        initialJumpHeight = 0;
        vertical_speed = 10;
        horizontal_speed = 1;
        rb.isKinematic = false;
        max_jump_height = 5;
        max_horizontal_speed = 6;

        while (gameManager == null){
            gameManager = GameObject.Find("GameManagerObj").GetComponent<GameManager>();
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            Jump();
        }
        // else if (Input.GetKey(KeyCode.S))
        // {
        //     MoveDown(vertical_speed);
        // }
        else if (Input.GetKey(KeyCode.A))
        {
            MoveLeft(horizontal_speed);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            MoveRight(horizontal_speed);
        }

        if (!isGrounded && transform.position.y >= initialJumpHeight + max_jump_height)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
        }

        float clampedXVelocity = Mathf.Clamp(rb.velocity.x, -max_horizontal_speed, max_horizontal_speed);
        rb.velocity = new Vector2(clampedXVelocity, rb.velocity.y);
    }

    void MoveDown(float vertical_speed)
    {
        rb.AddForce(Vector2.down * vertical_speed);
    }

    void MoveLeft(float horizontal_speed)
    {
        rb.AddForce(Vector2.left * horizontal_speed);
    }

    void MoveRight(float horizontal_speed)
    {
        rb.AddForce(Vector2.right * horizontal_speed);
    }

    void Jump()
    {
        initialJumpHeight = transform.position.y;
        rb.AddForce(Vector2.up * vertical_speed, ForceMode2D.Impulse);
        isGrounded = false;
        Debug.Log("Jumping");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            isGrounded = true;
            Debug.Log("Landed on Platform");
        }

        if (collision.gameObject.CompareTag("Lava")){

            gameManager.gameOver();
        }

        if (collision.gameObject.CompareTag("Finish"))
        {
            gameManager.LevelCompleted();
        }
    }
}