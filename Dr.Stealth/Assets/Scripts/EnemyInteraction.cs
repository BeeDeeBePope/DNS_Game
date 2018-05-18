using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInteraction : MonoBehaviour
{
    private EnemyMovemnt movemnt;
    private IInteractable currentInterraction;

    private void Start()
    {
        movemnt = GetComponent<EnemyMovemnt>();
    }
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
        currentInterraction.Interact();
        HealingInteractable healingInteractable = currentInterraction as HealingInteractable;
        if (healingInteractable != null)
        {
            healingInteractable.isHealing = false;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (!collision.gameObject.CompareTag("Interactable"))
        {
            return;
        }
        if (currentInterraction == collision.gameObject.GetComponent<IInteractable>())
        {
            currentInterraction = null;
        }
    }

    internal float InteractWithClosest() {
        currentInterraction.Interact();
        return currentInterraction.interactTime;
    }
}
