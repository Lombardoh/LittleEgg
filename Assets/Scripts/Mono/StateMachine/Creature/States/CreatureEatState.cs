using UnityEngine;

public class CreatureEatState : CreatureBaseState
{
    public override void OnEnter(CreatureManagerBase creature)
    {
        base.OnEnter(creature);
        creature.animatorManager.UpdateAnimatorValues("IsEating", true);
        creature.SetNeed(NeedType.Hunger, 1);
    }

    public override void OnExit(CreatureManagerBase creature)
    {
        creature.animatorManager.UpdateAnimatorValues("IsEating", false);
    }

    public override void Update(CreatureManagerBase creature)
    {
      
    }
}
