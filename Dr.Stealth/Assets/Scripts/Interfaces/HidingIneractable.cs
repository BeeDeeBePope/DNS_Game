using UnityEngine;

public abstract class HidingInteractable : MonoBehaviour, IInteractable
{
    public bool playerIsHidden;
    public abstract void Interact();

}