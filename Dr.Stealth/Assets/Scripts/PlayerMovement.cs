using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float Speed = 5;
    public float SneakingDivider = 2;
    private Rigidbody rb;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        //Sneaking
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Vector3 movement = new Vector3(moveHorizontal, this.rb.velocity.y/Speed, moveVertical);
            rb.velocity = movement * Speed / SneakingDivider;
        }
        else
        {
            Vector3 movement = new Vector3(moveHorizontal, this.rb.velocity.y/Speed, moveVertical);
            rb.velocity = movement * Speed;
        }

    }
}