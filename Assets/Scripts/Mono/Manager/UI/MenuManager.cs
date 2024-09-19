using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public Transform constructPanel;
    public SlotPrefabManager slotPrefab;
    private NeedSpriteDatas needSpriteDatas;
    public NeedRowManager needRow;

    void Start()
    {
        needSpriteDatas = (NeedSpriteDatas)ScriptableManager.Instance.RequestData(ScriptableType.NeedsSprites);
        FillConstructPanel();
    }

    private void FillConstructPanel()
    {
        foreach (NeedSpriteData needSpriteData in needSpriteDatas.needSpriteDatas)
        {
            if (needSpriteData.needType == NeedType.None) continue;
            SlotPrefabManager newSlot = Instantiate(slotPrefab, constructPanel);
            if (newSlot == null)
            {
                Debug.LogError("Failed to instantiate SlotPrefabManager.");
                continue;
            }

            newSlot.Initialize(needSpriteData);
            if (!newSlot.TryGetComponent<RectTransform>(out RectTransform slotRectTransform)) return;
            slotRectTransform.anchoredPosition = new Vector2(100, -150 * (needSpriteDatas.needSpriteDatas.IndexOf(needSpriteData) - 1) - 50);
        }
    }
}
