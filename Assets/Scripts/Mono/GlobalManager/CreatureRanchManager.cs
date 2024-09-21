using System.Collections.Generic;
using UnityEngine;

public class CreatureRanchGlobaloManager : MonoBehaviour
{
    public List<CreatureManagerBase> creatures;
    public Dictionary<CreatureRanchManager, HashSet<NeedType>> creaturesWithNeeds;

    private void OnEnable()
    {
        CreatureEvents.OnNewStationCreated += NewStationCreated;
        CreatureEvents.OnCreatureWithNeeds += UpdateCreatureWithNeeds;
    }

    private void OnDisable()
    {
        CreatureEvents.OnNewStationCreated -= NewStationCreated;
        CreatureEvents.OnCreatureWithNeeds -= UpdateCreatureWithNeeds;
    }

    private void Awake()
    {
        creaturesWithNeeds = new Dictionary<CreatureRanchManager, HashSet<NeedType>>();
    }

    private void AssignNeedStation(CreatureRanchManager creature, NeedType needType)
    {
        NeedStationManagerBase newStationTarget = StationEvents.OnNearestStationRequested.Invoke(this.transform.position, needType);
        if (newStationTarget == null) return;
        creature.SetTargetStations(newStationTarget);
    }

    private void UpdateCreatureWithNeeds(CreatureRanchManager creature, NeedType needType, ActionType action)
    {
        if (!creaturesWithNeeds.ContainsKey(creature))
        {
            creaturesWithNeeds[creature] = new HashSet<NeedType>();
        }

        var needsSet = creaturesWithNeeds[creature];

        switch (action)
        {
            case ActionType.Add:
                needsSet.Add(needType);
                AssignNeedStation(creature, needType);
                break;
            case ActionType.Remove:
                needsSet.Remove(needType);
                if (needsSet.Count == 0)
                {
                    creaturesWithNeeds.Remove(creature);
                }
                break;
        }
    }

    private void NewStationCreated(NeedType needType)
    {
        foreach (var entry in creaturesWithNeeds)
        {
            var creature = entry.Key;
            var needsSet = entry.Value;

            if (needsSet.Contains(needType))
            {
                AssignNeedStation(creature, needType);
            }
        }
    }

}
