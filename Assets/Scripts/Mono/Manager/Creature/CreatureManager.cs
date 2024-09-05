using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CreatureManagerBase : MonoBehaviour, ITickListener
{
    private readonly float warningThreshold = 70;
    public float interactDistance = 3;

    private Creature creature;
    private CreatureUIManager creatureUIManager;
    public CreatureStateManager creatureStateManager;
    public List<NeedType> unfullfiledNeedsTypes;
    public CreatureAnimatorManager animatorManager;
    public CreatureLocomotionManager locomotionManager;
    public CreatureInteractionManager interactionManager;
    private bool performinAction = false;

    public List<StationManagerBase> targetStations;

    private void Awake()
    {
        creatureUIManager = GetComponentInChildren<CreatureUIManager>();
        creatureStateManager = GetComponent<CreatureStateManager>();
        animatorManager = GetComponent<CreatureAnimatorManager>();
        locomotionManager = GetComponent<CreatureLocomotionManager>();
        interactionManager = GetComponent<CreatureInteractionManager>();
        creature = new ();
        unfullfiledNeedsTypes = new();
    }

    private void Start()
    {
        ((ITickListener)this).SubscribeToTicks(TickType.Large);
    }

    private void Update()
    {
        if (performinAction) return;
        MoveTowardsTarget();
    }

    public List<KeyValuePair<NeedType, float>> GetAllNeeds()
    {
        return creature.GetNeeds().GetAllNeeds();
    }

    private void MoveTowardsTarget()
    {
        if (targetStations.Count < 1) return;
        locomotionManager.MoveToDestination(targetStations[0].transform.position);
    }

    private void SetNeed(KeyValuePair<NeedType, float> need)
    {
        creature.Needs.SetNeed(need.Key, need.Value);
    }

    public void SetTargetStations(StationManagerBase station)
    {
        targetStations.Add(station);
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

            bool isNeedInUnfulfilledNeeds = unfullfiledNeedsTypes.Any(n => n == need.Key);

            if (need.Value > warningThreshold && !isNeedInUnfulfilledNeeds) { 
                creatureUIManager.UpdateNeedPanel(need.Key);
                unfullfiledNeedsTypes.Add(need.Key);

                CreatureEvents.OnCreatureWithNeeds?.Invoke(this, need.Key, ActionType.Add);

            }
            if (need.Value < warningThreshold && isNeedInUnfulfilledNeeds) {
                creatureUIManager.UpdateNeedPanel(need.Key);
                unfullfiledNeedsTypes.Remove(need.Key);

                CreatureEvents.OnCreatureWithNeeds?.Invoke(this, need.Key, ActionType.Remove);
            }
        }
        UIEvens.OnUpdateStatusUI?.Invoke(_needs);
    }
}
