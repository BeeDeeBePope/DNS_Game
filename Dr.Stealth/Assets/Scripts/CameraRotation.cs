using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour {

    public GameObject pivot;

    void Update () {
		if( Input.GetKey("q"))
        {
            pivot.transform.Rotate(0, Time.deltaTime, 0);
        }
	}

}
