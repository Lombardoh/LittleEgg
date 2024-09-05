using System.Collections.Generic;
using UnityEngine;

public class ScriptableManager : Singleton<ScriptableManager>
{
    [EnumNamedArray(typeof(ScriptableType))]
    public List<ScriptableObject> scritableList;
    public Sprite notFoundSprite;

    public ScriptableObject RequestData(ScriptableType scriptableType)
    {
        return scritableList[(int)scriptableType];
    }

    public Sprite GetNeedSprite(NeedType needType) 
    {
        NeedDatas needDatas = (NeedDatas)scritableList[0];
        return needDatas.needDatas[(int)needType].sprite ?? notFoundSprite;
    }
}
