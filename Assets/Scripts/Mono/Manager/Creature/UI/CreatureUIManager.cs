using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CreatureUIManager : MonoBehaviour
{
    public Transform needPanel;
    public Transform statPanel;
    public List<NeedSpriteData> UnfullfiledNeeds;
    public Camera mainCamera;
    public SpriteValuePairManager spriteValuePrefab;
    public ImageManager imageManagerPrefab;
    private List<SpriteValuePairManager> needsValueList;
    private List<SpriteValuePairManager> statsValueList;

    public bool IsActive {  get; private set; } = false;

    private void Start()
    {
        statsValueList = new();
        needsValueList = new();
        if (!IsActive) return;
        InitNeedsPanel();
        InitStatsPanel();
    }

    void Update()
    {   
        if (!IsActive) return;        
        Vector3 directionToCamera = mainCamera.transform.position - transform.position;
        directionToCamera.y = 0;
        transform.rotation = Quaternion.LookRotation(-directionToCamera);
    }


    private void InitNeedsPanel()
    {
        NeedSpriteDatas needSpriteDatas = (NeedSpriteDatas)ScriptableManager.Instance.scriptableList[(int)ScriptableType.NeedsSprites];
        int index = 0;

        foreach (NeedSpriteData needData in needSpriteDatas.needSpriteDatas)
        {
            if (needData.needType == NeedType.None) continue;

            SpriteValuePairManager newSpriteValuePrefab = Instantiate(spriteValuePrefab, needPanel);

            Vector3 newPosition = newSpriteValuePrefab.transform.localPosition;
            newPosition.y -= index;
            newSpriteValuePrefab.transform.localPosition = newPosition;

            newSpriteValuePrefab.Init("100", needData.sprite);
            needsValueList.Add(newSpriteValuePrefab);

            index++;
        }
    }

    private void InitStatsPanel()
    {
        StatSpriteDatas statSpriteDatas = (StatSpriteDatas)ScriptableManager.Instance.scriptableList[(int)ScriptableType.StatsSprites];
        int index = 0;

        foreach (StatSpriteData statSpriteData in statSpriteDatas.statSpriteDatas)
        {
            if (statSpriteData.statType == StatType.None) continue;

            SpriteValuePairManager newSpriteValuePrefab = Instantiate(spriteValuePrefab, statPanel);

            Vector3 newPosition = newSpriteValuePrefab.transform.localPosition;
            newPosition.x += index;
            newSpriteValuePrefab.transform.localPosition = newPosition;

            newSpriteValuePrefab.Init("10", statSpriteData.sprite);
            statsValueList.Add(newSpriteValuePrefab);

            index++;
        }
    }

    public void UpdateNeedPanel(List<KeyValuePair<NeedType, float>> needs)
    {
        for (int i = 0; i < needsValueList.Count(); i++)
        {
            needsValueList[i].SetText(needs[i].Value.ToString());
        }
    }

    public void TogglePanel()
    {
        IsActive = !IsActive;
        needPanel.gameObject.SetActive(IsActive);
        statPanel.gameObject.SetActive(IsActive);

        if (!IsActive) return;
        InitNeedsPanel();
        InitStatsPanel();
    }
}
