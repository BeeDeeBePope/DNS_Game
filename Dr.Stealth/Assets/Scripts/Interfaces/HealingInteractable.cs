using UnityEngine;

public abstract class HealingInteractable : MonoBehaviour, IInteractable {
    public bool isHealing;
    [SerializeField]private float _interactTime;

    public float interactTime {
        get {
            return _interactTime;
        }
        set {
            _interactTime = value;
        }
    }

    public abstract void Interact();

}