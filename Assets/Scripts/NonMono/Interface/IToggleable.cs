using UnityEngine;

public interface IToggleable
{
    public Transform Transform { get; }
    public bool Detecting { get; set; }
    public void ToggleDetecting(bool status)
    {
        Transform.gameObject.SetActive(status);
        Detecting = status;
    }
}
