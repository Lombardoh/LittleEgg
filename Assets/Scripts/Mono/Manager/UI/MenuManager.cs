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
            SlotPrefabManager newSlot = Instantiate(slotPrefab, menuPanel);
            if (newSlot == null)
            {
                Debug.LogError("Failed to instantiate SlotPrefabManager.");
                continue;
            }

            newSlot.Initialize(needData);

            RectTransform slotRectTransform = newSlot.GetComponent<RectTransform>();
            if (slotRectTransform != null)
            {
                slotRectTransform.anchoredPosition = new Vector2(100, -150 * needDatas.needDatas.IndexOf(needData) - 50);
            }
        }
    }
}
