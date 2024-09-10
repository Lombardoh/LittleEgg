using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public Transform constructPanel;
    private Dictionary<string, NeedRowManager> statusPanelText = new();
    public SlotPrefabManager slotPrefab;
    private NeedDatas needDatas;
    private readonly float verticalSpacing = 60f;
    public NeedRowManager needRow;

    void Start()
    {
        needDatas = (NeedDatas)ScriptableManager.Instance.RequestData(ScriptableType.Need);
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

            //NeedRowManager newRow = Instantiate(needRow, statusPanel);
            //if (newRow == null) return;

            //newRow.SetText(needData.needType.ToString(), "0");
            //statusPanelText.Add(needData.needType.ToString(), newRow);
            //if (!newRow.TryGetComponent<RectTransform>(out var rowRectTransform)) return;

            //rowRectTransform.anchoredPosition = new Vector2(0, yOffset);
            //yOffset -= verticalSpacing;
        }
    }
}
