using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CreatureUIManager : MonoBehaviour
{
    public Transform needPanel;
    public Transform UrgentNeedPanel;
    public bool IsActive {  get; private set; } = false;
    public List<NeedData> UnfullfiledNeeds;
    private int currentNeedPanelSpriteIndex = 0;
    private bool isTicking = false;
    public Camera mainCamera;
    public SpriteValuePairManager spriteValuePrefab;
    public ImageManager imageManagerPrefab;
    private List<SpriteValuePairManager> needValueList;

    private void Start()
    {
        needValueList = new();
        InitNeedPanels();
    }

    void Update()
    {   
        if (!IsActive) return;        
        Vector3 directionToCamera = mainCamera.transform.position - transform.position;
        directionToCamera.y = 0;
        transform.rotation = Quaternion.LookRotation(-directionToCamera);
    }

    public void UpdateUrgentNeedPanel(NeedType needType)
    {
        bool exists = UnfullfiledNeeds.Any(needData => needData.needType == needType);

        if (exists){ UnfullfiledNeeds.RemoveAll(needData => needData.needType == needType); return; }

        Sprite sprite = ScriptableManager.Instance.GetNeedSprite(needType);
        NeedData newUnfullfiledNeed = new(sprite, needType);
        UnfullfiledNeeds.Add(newUnfullfiledNeed);
    }

    private void InitNeedPanels()
    {
        NeedDatas datas = (NeedDatas)ScriptableManager.Instance.scriptableList[(int)ScriptableType.Need];
        int index = 0;

        foreach (NeedData needData in datas.needDatas)
        {
            if (needData.needType == NeedType.None) continue;

            SpriteValuePairManager newSpriteValuePrefab = Instantiate(spriteValuePrefab, needPanel);

            Vector3 newPosition = newSpriteValuePrefab.transform.localPosition;
            newPosition.y -= index;
            newSpriteValuePrefab.transform.localPosition = newPosition;

            newSpriteValuePrefab.Init("100", needData.sprite);
            needValueList.Add(newSpriteValuePrefab);


            ImageManager newImage = Instantiate(imageManagerPrefab, UrgentNeedPanel);
            newImage.SetImage(needData.sprite);
            Vector3 newImagePosition = newImage.transform.localPosition;
            newImagePosition.x += index * 1.1f;
            newImage.transform.localPosition = newImagePosition;

            index++;
        }
    }

    public void UpdateNeedPanel(List<KeyValuePair<NeedType, float>> needs)
    {
        for (int i = 0; i < needValueList.Count(); i++)
        {
            needValueList[i].SetText(needs[i].Value.ToString());
        }
    }

}
