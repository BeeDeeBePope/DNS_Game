using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float Speed = 5;
    public float SneakingDivider = 2;
    public float YMin = 0, YMax = 0.25f;
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
            Vector3 movement = new Vector3(moveHorizontal, -1, moveVertical);
            rb.velocity = movement * Speed / SneakingDivider;
        }
        else
        {
            Vector3 movement = new Vector3(moveHorizontal, 1, moveVertical);
            rb.velocity = movement * Speed;
        }
        rb.position = new Vector3
       (
           this.transform.position.x,
           Mathf.Clamp(rb.position.y, YMin, YMax),
           this.transform.position.z
       );


    }
}