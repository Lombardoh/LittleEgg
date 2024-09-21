using UnityEngine;

public class CreatureEatState : CreatureBaseState
{
    public override void OnEnter(CreatureRanchManager creature)
    {
        base.OnEnter(creature);
        creature.animatorManager.UpdateAnimatorValues("IsEating", true);
        creature.SetNeed(NeedType.Hunger, 1);
    }

    public override void OnExit(CreatureRanchManager creature)
    {
        creature.animatorManager.UpdateAnimatorValues("IsEating", false);
    }

    public override void Update(CreatureRanchManager creature)
    {
      
    }
}
