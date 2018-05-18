using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private Rigidbody  rb;

    private bool canInteract;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        movement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (canInteract)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                currentInterraction.Interact();
                //HealingInteractable healingInteractable = currentInterraction as HealingInteractable;
                //if (healingInteractable != null)
                //{
                //    healingInteractable.isHealing = true;
                //}
            }
        }
    }
    private IInteractable currentInterraction;
    private PlayerMovement movement;

    private void OnTriggerEnter(Collider collision)
    {
        if (!collision.gameObject.CompareTag("Interactable"))
        {
            return;
        }
        currentInterraction = collision.gameObject.GetComponent<IInteractable>();
        canInteract = true;
        if (currentInterraction.IsLoosingControl)
        {
            currentInterraction.Movement = movement;
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
            currentInterraction.Movement = null;
            currentInterraction = null;
            canInteract = false;
        }
    }

}
