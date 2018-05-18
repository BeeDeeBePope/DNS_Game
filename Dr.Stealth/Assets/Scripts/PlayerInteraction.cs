using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private Rigidbody  rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private IInteractable currentInterraction;
    private void OnTriggerEnter(Collider collision)
    {
        if (!collision.gameObject.CompareTag("Interactable"))
        {
            return;
        }
        currentInterraction = collision.gameObject.GetComponent<IInteractable>();
    }
    
    private void OnTriggerStay(Collider collision)
    {
        if (currentInterraction == null)
        {
            return;
        }
        if (Input.GetKey(KeyCode.E))
        {
            currentInterraction.Interact();
            HealingInteractable healingInteractable = currentInterraction as HealingInteractable;
            if (healingInteractable!=null)
            {
                healingInteractable.isHealing = true;
            }
            HidingInteractable hidingInteractable = currentInterraction as HidingInteractable;
            if (hidingInteractable != null)
            {
                
                if (hidingInteractable.playerIsHidden != true)
                {
                    hidingInteractable.playerIsHidden = true;
                    rb.constraints = RigidbodyConstraints.FreezePosition;
                    transform.position += new Vector3(0.0f, -2.0f, 0.0f);
                }
                else
                {
                    hidingInteractable.playerIsHidden = false;
                    transform.position -= new Vector3(0.0f, -2.0f, 0.0f);
                }
                
            }
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (!collision.gameObject.CompareTag("Interactable"))
        {
            return;
        }
        if(currentInterraction == collision.gameObject.GetComponent<IInteractable>())
        {
            currentInterraction = null;
        }
    }

}
