using UnityEngine;

public abstract class HealingInteractable : MonoBehaviour, IInteractable
{
    public bool isHealing;
    public abstract void Interact();

}