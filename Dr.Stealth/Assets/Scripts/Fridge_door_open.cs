using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fridge_door_open : MonoBehaviour
{
    public GameObject interUIscript;
    public GameObject popup_door, popup_interaction;
    public GameObject door, player;
    public float smooth = 1f;
    private bool isOpen = false;
    private Quaternion targetRotation;
    private GameObject popupInstance_door, popupInstance_interaction;
    private TextMesh popup_text, popup_int_text;
    void Start()
    {
        targetRotation = door.transform.localRotation;
    }

    private void OnTriggerEnter(Collider interaction)
    {
        popupInstance_door = Instantiate(popup_door, player.transform.position + new Vector3(1, 1), Quaternion.identity, player.transform);
    }

    private void OnTriggerExit(Collider other)
    {
        Destroy(popupInstance_door);
    }

    void OnTriggerStay(Collider interaction)
    { 
        if (Input.GetKeyDown("e"))
        {
            popup_text = popupInstance_door.GetComponent<TextMesh>();
            if (isOpen == false)
            {
                popupInstance_interaction = Instantiate(popup_interaction, transform.position + new Vector3(1, 1), Quaternion.identity, transform);
                popup_int_text = popupInstance_interaction.GetComponent<TextMesh>();
                popup_int_text.text = "Press F to interact";
                targetRotation *= Quaternion.AngleAxis(-90, Vector3.forward);
                isOpen = true;
            }
            else
            {
                Destroy(popupInstance_interaction);
                targetRotation *= Quaternion.AngleAxis(90, Vector3.forward);
                isOpen = false;
            }
        }
        if (Input.GetKeyDown("f") && isOpen)
        {
            StartCoroutine("TaskDelay");
        }
        door.transform.localRotation = Quaternion.Lerp(door.transform.localRotation, targetRotation, smooth * Time.deltaTime);
    }

    IEnumerator TaskDelay()
    {
        Debug.Log("przed pauzą");
        popup_int_text.text = "Interaction in progress";
        yield return new WaitForSeconds(3);
        Debug.Log("Po pauzie");
        popup_int_text.text = "Interaction complete!";
        interUIscript.GetComponent<SimpleUI>().CompleteTask();
    }
}
