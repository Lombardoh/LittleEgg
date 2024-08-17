using System.Collections.Generic;

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
        return Needs[needType];
    }

    public void SetNeed(NeedType needType, float value)
    {
        Needs[needType] = value;
    }

    public List<KeyValuePair<NeedType, float>> GetAllNeeds()
    {
        return new List<KeyValuePair<NeedType, float>>(Needs);
    }
}
