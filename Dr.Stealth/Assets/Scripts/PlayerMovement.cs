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
        Vector3 movement = new Vector3(moveHorizontal, rb.velocity.y / Speed, moveVertical);
        rb.velocity = movement * Speed;
        //Sneaking
        if (Input.GetKey(KeyCode.LeftShift))
        {

            rb.velocity /= SneakingDivider;
        }
        if (movement != Vector3.zero)
        {
         
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.3f);
        }

    }
}