using System.Collections.Generic;
using UnityEngine;

public class TrainStationManagerBase : StationManagerBase, IInteractable<StatType>
{
    protected StatType statType;
    protected float trainRate;

    public virtual void Initialize(StatType statType, float trainRate)
    {
        this.statType = statType;
        this.trainRate = trainRate;
    }

    public virtual StatType GetStatType()
    {
        return statType;
    }

    public KeyValuePair<StatType, float> Interact()
    {
        return new KeyValuePair<StatType, float>(statType, trainRate);
    }
}
