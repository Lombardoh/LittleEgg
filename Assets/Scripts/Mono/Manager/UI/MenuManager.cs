using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public Transform constructPanel;
    public SlotPrefabManager slotPrefab;
    private NeedDatas needDatas;
    public NeedRowManager needRow;

    void Start()
    {
        needDatas = (NeedDatas)ScriptableManager.Instance.RequestData(ScriptableType.Needs);
        FillConstructPanel();
    }

    private void FillConstructPanel()
    {
        foreach (NeedData needData in needDatas.needDatas)
        {
            if (needData.needType == NeedType.None) continue;
            SlotPrefabManager newSlot = Instantiate(slotPrefab, constructPanel);
            if (newSlot == null)
            {
                Debug.LogError("Failed to instantiate SlotPrefabManager.");
                continue;
            }

            newSlot.Initialize(needData);
            if (!newSlot.TryGetComponent<RectTransform>(out RectTransform slotRectTransform)) return;
            slotRectTransform.anchoredPosition = new Vector2(100, -150 * (needDatas.needDatas.IndexOf(needData) - 1) - 50);
        }
    }
}
