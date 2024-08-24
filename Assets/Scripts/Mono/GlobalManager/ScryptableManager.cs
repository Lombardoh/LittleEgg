using UnityEngine;

public class ScriptableManager : Singleton<ScriptableManager>
{
    [SerializeField] private NeedDatas needDatas;

    public ScriptableObject RequestData(EnumType enumType)
    {
        switch (enumType) 
        {
            case EnumType.Need:
                return needDatas;
            default: return null;
        }
    }
}
