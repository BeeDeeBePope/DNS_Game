using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothRotation : MonoBehaviour {

    public float smooth = 1f;
    private Quaternion targetRotation;
    void Start()
    {
        targetRotation = transform.rotation;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            targetRotation *= Quaternion.AngleAxis(45, Vector3.up);
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            targetRotation *= Quaternion.AngleAxis(-45, Vector3.up);
        }
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 10 * smooth * Time.deltaTime);
    }
}
