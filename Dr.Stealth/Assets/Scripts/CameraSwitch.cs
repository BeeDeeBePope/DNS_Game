using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour {

    public GameObject Orto;
    public GameObject Persp;
    public GameObject Back;
    public GameObject char3d;
    public GameObject char2d;
    public GameObject background;
	
	// Update is called once per frame
	void Update ()
    {
		if( Input.GetKeyDown("p") )
        {
            Persp.SetActive(true);
            char3d.SetActive(true);
            background.SetActive(false);
            char2d.SetActive(false);
            Orto.SetActive(false);
            Back.SetActive(false);
        }
        if( Input.GetKeyDown("o") )
        {
            Persp.SetActive(false);
            char3d.SetActive(false);
            Back.SetActive(false);
            background.SetActive(true);
            char2d.SetActive(true);
            Orto.SetActive(true);
        }
        if( Input.GetKeyDown("i"))
        {
            Back.SetActive(true);
            Persp.SetActive(false);
            Orto.SetActive(false);
            char3d.SetActive(true);
            background.SetActive(false);
            char2d.SetActive(false);
            
        }
    }
}
