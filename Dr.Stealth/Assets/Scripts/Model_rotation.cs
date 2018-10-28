using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Model_rotation : MonoBehaviour {

    public float smooth = 1f;
    public GameObject player3d;
    private Vector3 movement;
    private Animator main_anim;

    void Start()
    {
        main_anim = player3d.GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate () {

        float verticalAxis = Input.GetAxis("Vertical");
        float horizontalAxis = Input.GetAxis("Horizontal");

        if(verticalAxis != 0 || horizontalAxis != 0)
        {
            main_anim.Play("Root|Run_loop");
        }
        else
        {
            main_anim.Play("Root|Idle");
        }
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

        /*if (horizontalAxis > 0)
        {
            targetRotation = Quaternion.AngleAxis(90, Vector3.up);
        }
        if (horizontalAxis < 0)
        {
            targetRotation = Quaternion.AngleAxis(-90, Vector3.up);
        }
        if (verticalAxis > 0)
        {
            targetRotation = Quaternion.AngleAxis(180, Vector3.up);
        }
        if (verticalAxis < 0)
        {
            targetRotation = Quaternion.AngleAxis(0, Vector3.up);
        }*/

        var desiredMoveDirection = forward * verticalAxis + right * horizontalAxis;

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(desiredMoveDirection), smooth);

        //movement = new Vector3(horizontalAxis * right , 0f, verticalAxis * forward);
        //transform.rotation = Quaternion.LookRotation(movement);
        //transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 10 * smooth * Time.deltaTime);
    }
}
