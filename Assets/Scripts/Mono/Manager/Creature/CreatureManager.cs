using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CreatureManagerBase : MonoBehaviour, ITickListener
{
    private readonly float warningThreshold = 70;
    public float interactDistance = 3;

    private Creature creature;
    private CreatureUIManager creatureUIManager;
    private CreatureStateManager creatureStateManager;
    public List<NeedType> UnfullfiledNeedsTypes;
    public CreatureAnimatorManager animatorManager;
    public CreatureLocomotionManager locomotionManager;

    public Transform target;

    private void OnEnable()
    {
        StationEvents.OnResourceCreated += ResourceCreated;
    }

    private void OnDisable()
    {
        StationEvents.OnResourceCreated -= ResourceCreated;
    }

    private void Awake()
    {
        creatureUIManager = GetComponentInChildren<CreatureUIManager>();
        creatureStateManager = GetComponent<CreatureStateManager>();
        animatorManager = GetComponent<CreatureAnimatorManager>();
        locomotionManager = GetComponent<CreatureLocomotionManager>();
        creature = new ();
        UnfullfiledNeedsTypes = new();
    }

    private void Start()
    {
        ((ITickListener)this).SubscribeToTicks(TickType.Large);
    }

    private void Update()
    {
        MoveTowardsTarget();
    }

    public List<KeyValuePair<NeedType, float>> GetAllNeeds()
    {
        return creature.GetNeeds().GetAllNeeds();
    }

    private void MoveTowardsTarget()
    {
        if (target == null) return;

        locomotionManager.MoveToDestination(target.position);
    }

    private void ResourceCreated(NeedType needType, Transform target)
    {
        if (creature.NeedFullfilled(needType)) return;
        this.target = target;
        creatureStateManager.OnStateChangeRequested(CreatureStateType.Walking);
    }

    public void OnTicked()
    {
        UpdateCreatureNeeds();
    }

    private void UpdateCreatureNeeds()
    {
        List<KeyValuePair<NeedType, float>> _needs = creature.GetNeeds().GetAllNeeds();

        foreach (var need in _needs)
        {
            creature.Needs.SetNeed(need.Key, Mathf.Min(100, need.Value + 1));

            bool isNeedInUnfulfilledNeeds = UnfullfiledNeedsTypes.Any(n => n == need.Key);

            if (need.Value > warningThreshold && !isNeedInUnfulfilledNeeds) { 
                creatureUIManager.UpdateNeedPanel(need.Key);
                UnfullfiledNeedsTypes.Add(need.Key);
            }
            if (need.Value < warningThreshold && isNeedInUnfulfilledNeeds) {
                creatureUIManager.UpdateNeedPanel(need.Key);
                UnfullfiledNeedsTypes.Remove(need.Key);
            }
        }
        UIEvens.OnUpdateStatusUI?.Invoke(_needs);
    }


}
