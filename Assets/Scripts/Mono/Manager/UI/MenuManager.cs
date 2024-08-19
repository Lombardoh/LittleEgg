using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public Transform menuPanel;
    public SlotPrefabManager slotPrefab;
    public NeedDatas needDatas;

    void Start()
    {
        menuPanel = transform.Find("MenuPanel");
        CreateSlotPrefabs();
    }

    private void CreateSlotPrefabs()
    {
        foreach (var needData in needDatas.needDatas)
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
            slotRectTransform.anchoredPosition = new Vector2(100, -150 * (needDatas.needDatas.IndexOf(needData) - 1 ) - 50);   
        }
    }
}
