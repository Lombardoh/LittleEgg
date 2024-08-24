using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public Transform menuPanel;
    public Transform statusPanel;
    private Dictionary<string, NeedRowManager> statusPanelText = new();
    public SlotPrefabManager slotPrefab;
    public NeedDatas needDatas;
    private readonly float verticalSpacing = 60f;
    public NeedRowManager needRow;

    private void OnEnable()
    {
        UIEvens.OnUpdateStatusUI += UpdateStatusUI;
    }    
    
    private void OnDisable()
    {
        UIEvens.OnUpdateStatusUI -= UpdateStatusUI;
    }

    void Start()
    {
        menuPanel = transform.Find("MenuPanel");
        needDatas = (NeedDatas)ScriptableManager.Instance.RequestData(EnumType.Need);
        FillUIMenues();
    }

    private void FillUIMenues()
    {
        if (!statusPanel.TryGetComponent<RectTransform>(out RectTransform panelRectTransform)) return;
        float yOffset = panelRectTransform.rect.height / 2 - verticalSpacing;

        foreach (NeedData needData in needDatas.needDatas)
        {
            if (needData.needType == NeedType.None) continue;
            SlotPrefabManager newSlot = Instantiate(slotPrefab, menuPanel);
            if (newSlot == null)
            {
                Debug.LogError("Failed to instantiate SlotPrefabManager.");
                continue;
            }

            newSlot.Initialize(needData);
            if (!newSlot.TryGetComponent<RectTransform>(out RectTransform slotRectTransform)) return;
            slotRectTransform.anchoredPosition = new Vector2(100, -150 * (needDatas.needDatas.IndexOf(needData) - 1) - 50);

            NeedRowManager newRow = Instantiate(needRow, statusPanel);
            if (newRow == null) return;

            newRow.SetText(needData.needType.ToString(), "0");
            statusPanelText.Add(needData.needType.ToString(), newRow);
            if (!newRow.TryGetComponent<RectTransform>(out var rowRectTransform)) return;

            rowRectTransform.anchoredPosition = new Vector2(0, yOffset);
            yOffset -= verticalSpacing;
        }
    }

    private void UpdateStatusUI(List<KeyValuePair<NeedType, float>> needs)
    {
        foreach (KeyValuePair<NeedType, float> need in needs)
        {
            statusPanelText[need.Key.ToString()].SetText(need.Key.ToString(), need.Value.ToString());
        }
    }
}
