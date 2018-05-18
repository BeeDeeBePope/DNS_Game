public interface IInteractable
{
    bool IsLoosingControl { get; set; }
    PlayerMovement Movement { get; set; }
    void Interact();
}