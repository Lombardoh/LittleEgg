public class CreatureDrinkState : CreatureBaseState
{
    public override void OnEnter(CreatureRanchManager creature)
    {
        base.OnEnter(creature);
        creature.animatorManager.UpdateAnimatorValues("IsDrinking", true);
        creature.SetNeed(NeedType.Thirst, 1);
    }

    public override void OnExit(CreatureRanchManager creature)
    {
        creature.animatorManager.UpdateAnimatorValues("IsDrinking", false);
    }

    public override void Update(CreatureRanchManager creature)
    {
    }
}