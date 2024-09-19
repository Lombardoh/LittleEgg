using System.Collections.Generic;

public interface IInteractable<T>
{
    KeyValuePair<T, float> Interact();
}
