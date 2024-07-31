using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    public Rigidbody2D rb;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.W))
        {
            MoveUp(speed);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            MoveDown(speed);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            MoveLeft(speed);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            MoveRight(speed);
        }
        else
        {
            rb.velocity = new Vector2(0, 0);
        }
        
    }

    void MoveUp(float speed)
    {

        rb.velocity = new Vector2(0, 1)*speed;

    }

    void MoveDown(float speed)
    {

        rb.velocity = new Vector2(0, -1)*speed;

    }

    void MoveLeft(float speed)
    {

        rb.velocity = new Vector2(-1, 0)*speed;

    }

    void MoveRight(float speed)
    {

        rb.velocity = new Vector2(1, 0)*speed;

    }
}
