using UnityEngine;

[System.Serializable]
public class NeedSpriteData
{
    public Sprite sprite;
    public NeedType needType;

    public NeedSpriteData(Sprite sprite, NeedType needType)
    {
        this.sprite = sprite;
        this.needType = needType;
    }
}
