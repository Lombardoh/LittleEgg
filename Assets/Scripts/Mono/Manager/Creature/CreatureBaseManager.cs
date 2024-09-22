using UnityEngine;

public class CreatureManagerBase : MonoBehaviour, IClickable
{
    protected Creature creature;


    protected virtual void Awake()
    {
        creature = new();
    }

    public virtual void OnClicked()
    {
        throw new System.NotImplementedException();
    }
}
