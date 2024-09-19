using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Needs
{
    public Dictionary<NeedType, float> needs { get; set; }

    public Needs(float hunger, float thirst, float sleep, float boredom)
    {
        needs = new Dictionary<NeedType, float>
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
        return needs[needType];
    }

    public void SetNeed(NeedType needType, float value)
    {
        float clampedValue = Mathf.Clamp(value, 0, 100);
        needs[needType] = clampedValue;
    }


    public List<KeyValuePair<NeedType, float>> GetAllNeeds()
    {
        return needs.Where(need => need.Key != NeedType.None).ToList();
    }
}
