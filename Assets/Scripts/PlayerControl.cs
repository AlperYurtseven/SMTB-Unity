using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    public Rigidbody2D rb;
    public float vertical_speed;
    public float horizontal_speed;

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
            MoveUp(vertical_speed);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            MoveDown(vertical_speed);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            MoveLeft(horizontal_speed);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            MoveRight(horizontal_speed);
        }
        
    }

    void MoveUp(float vertical_speed)
    {

        rb.AddForce(transform.up * vertical_speed);

    }

    void MoveDown(float vertical_speed)
    {

        rb.AddForce(-transform.up * vertical_speed);

    }

    void MoveLeft(float horizontal_speed)
    {

        rb.AddForce(-transform.right * horizontal_speed);

    }

    void MoveRight(float horizontal_speed)
    {

        rb.AddForce(transform.right * horizontal_speed);

    }
}
