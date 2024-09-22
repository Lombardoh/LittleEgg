using UnityEngine;

public class CreatureLaberynthManager : CreatureManagerBase
{
    public override void OnClicked()
    {
        Debug.Log(gameObject.name);
    }
}
