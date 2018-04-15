using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
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
