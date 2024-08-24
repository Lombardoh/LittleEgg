using UnityEngine;

public class ScriptableManager : Singleton<ScriptableManager>
{
    public Sprite notFoundSprite;
    public NeedDatas needDatas;

    public ScriptableObject RequestData(EnumType enumType)
    {
        switch (enumType) 
        {
            case EnumType.Need:
                return needDatas;
            default: return null;
        }
    }

    public Sprite GetNeedSprite(NeedType needType) 
    {
        return needDatas.needDatas[(int)needType].sprite ?? notFoundSprite;
    }
}
