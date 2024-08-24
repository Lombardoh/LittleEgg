public class CreatureEatState : CreatureBaseState
{
    public override void OnEnter(CreatureManagerBase creature)
    {
        creature.animatorManager.UpdateAnimatorValues("IsEating", true);
    }

    public override void OnExit(CreatureManagerBase creature)
    {
        creature.animatorManager.UpdateAnimatorValues("IsEating", false);
    }

    public override void Update(CreatureManagerBase creature)
    {
    }
}