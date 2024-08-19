using UnityEngine;
using System.Linq;

[System.Serializable]
public class NeedData
{
    public Sprite sprite;
    public NeedType needType;

    public NeedData(Sprite sprite, NeedType needType)
    {
        this.sprite = sprite;
        this.needType = needType;
    }
}
