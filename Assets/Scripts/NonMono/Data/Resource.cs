using UnityEditor.iOS;

public class Resource
{
    public float maxAmount;
    public float currentAmount;
    public NeedType needType;

    public Resource(NeedType needType, float maxAmount, float currentAmount)
    {
        this.needType = needType;
        this.maxAmount = maxAmount;
        this.currentAmount = currentAmount;
    }

    public float GetResouceValue()
    {
        return currentAmount;
    }
    public void SetResouceValue(float newValue)
    {
        currentAmount = newValue;
    }
    public NeedType GetNeedType()
    {
        return needType;
    }
}
