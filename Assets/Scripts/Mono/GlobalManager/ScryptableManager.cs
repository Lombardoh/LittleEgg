using System.Collections.Generic;
using UnityEngine;

public class ScriptableManager : Singleton<ScriptableManager>
{
    [EnumNamedArray(typeof(ScriptableType))]
    public List<ScriptableObject> scriptableList;
    public Sprite notFoundSprite;

    public ScriptableObject RequestData(ScriptableType scriptableType)
    {
        return scriptableList[(int)scriptableType];
    }

    public Sprite GetNeedSprite(NeedType needType) 
    {
        NeedSpriteDatas needSpriteDatas = (NeedSpriteDatas)scriptableList[0];
        return needSpriteDatas.needSpriteDatas[(int)needType].sprite ?? notFoundSprite;
    }
}
