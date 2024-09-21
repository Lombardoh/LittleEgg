public class CreatureWalkState : CreatureBaseState
{
    public override void OnEnter(CreatureRanchManager creature)
    {
        creature.animatorManager.UpdateAnimatorValues("IsWalking", true);
    }

    public override void OnExit(CreatureRanchManager creature)
    {
        creature.animatorManager.UpdateAnimatorValues("IsWalking", false);
    }

    public override void Update(CreatureRanchManager creature)
    {
    }
}