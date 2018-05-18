using UnityEngine;

public abstract class HealingInteractable : MonoBehaviour, IInteractable
{
    public bool isHealing;

    public bool IsLoosingControl
    {
        get
        {
            throw new System.NotImplementedException();
        }

        set
        {
            throw new System.NotImplementedException();
        }
    }

    public PlayerMovement Movement
    {
        get
        {
            throw new System.NotImplementedException();
        }

        set
        {
            throw new System.NotImplementedException();
        }
    }

    public abstract void Interact();

}