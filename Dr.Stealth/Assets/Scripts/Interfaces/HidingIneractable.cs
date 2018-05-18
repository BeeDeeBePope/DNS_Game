using UnityEngine;

public abstract class HidingInteractable : MonoBehaviour, IInteractable
{
    [SerializeField] private bool _isLoosingControl;
    public bool IsLoosingControl
    {
        get { return _isLoosingControl; }
        set { _isLoosingControl = value; }
    }

    [SerializeField] private PlayerMovement _movement;
    public PlayerMovement Movement
    {
        get { return _movement; }
        set { _movement = value; }
    }

    public abstract void Interact();

}