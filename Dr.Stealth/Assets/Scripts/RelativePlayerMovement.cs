using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Variables._Definitions;

public class RelativePlayerMovement : MonoBehaviour {

    public float speedMeUp = 1;
    public GameObject animBillboard;
    private Animator main_anim;
    public Vector3Variable PositionVariable;

    void Start()
    {
        main_anim = animBillboard.GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        //reading the input:
        float verticalAxis = -Input.GetAxis("Horizontal");
        float horizontalAxis = Input.GetAxis("Vertical");   //ZAMIENIŁEM HORIZONTAL Z VERTICAL WIĘC MOZE BYĆ COŚ NIE TAK W PRZYSZŁOŚCI!!!

        //assuming we only using the single camera:
        var camera = Camera.main;

        //camera forward and right vectors:
        var forward = camera.transform.forward;
        var right = camera.transform.right;

        //project forward and right vectors on the horizontal plane (y = 0)
        forward.y = 0f;
        right.y = 0f;
        forward.Normalize();
        right.Normalize();

        //this is the direction in the world space we want to move:
        var desiredMoveDirection = forward * verticalAxis + right * horizontalAxis;

        //now we can apply the movement:
        transform.Translate(desiredMoveDirection * speedMeUp * Time.deltaTime);

        if(verticalAxis > 0)
        {
            animBillboard.transform.localScale = new Vector3(-2, 2, 2);
            main_anim.Play("Char_sprite_test");
        }
        if(verticalAxis < 0)
        {
            animBillboard.transform.localScale = new Vector3(2, 2, 2);
            main_anim.Play("Char_sprite_test");
        }
        if(verticalAxis == 0)
        {
            main_anim.Play("Idle");
        }
        PositionVariable.Value = transform.position;
    }

}
