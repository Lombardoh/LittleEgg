public class CreatureWalkState : CreatureBaseState
{
    public override void OnEnter(CreatureManagerBase creature)
    {
        creature.animatorManager.UpdateAnimatorValues("IsWalking", true);
    }

    public override void OnExit(CreatureManagerBase creature)
    {
        creature.animatorManager.UpdateAnimatorValues("IsWalking", false);
    }

    public override void Update(CreatureManagerBase creature)
    {
    }
}