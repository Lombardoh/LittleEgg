using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class NeedsBase
{
    public Dictionary<NeedType, float> Needs { get; set; }

    public NeedsBase(float hunger, float thirst, float sleep, float boredom)
    {
        Needs = new Dictionary<NeedType, float>
        {
            { NeedType.Hunger, hunger },
            { NeedType.Thirst, thirst },
            { NeedType.Sleep, sleep },
            { NeedType.Boredom, boredom }
        };
    }

    public float GetNeed(NeedType needType)
    {
        if(needType == NeedType.None) { return 0; }
        return Needs[needType];
    }

    public void SetNeed(NeedType needType, float value)
    {
        float clampedValue = Mathf.Clamp(value, 0, 100);
        Needs[needType] = clampedValue;
        Debug.Log(clampedValue);
    }


    public List<KeyValuePair<NeedType, float>> GetAllNeeds()
    {
        return Needs.Where(need => need.Key != NeedType.None).ToList();
    }
}
