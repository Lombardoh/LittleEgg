using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class SpriteValuePairManager : MonoBehaviour
{
    private Image needImage;
    private TextMeshProUGUI needValue;

    private void Awake()
    {
        needImage = GetComponentInChildren<Image>();
        needValue = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void Init(string text, Sprite sprite)
    {
        needValue.text = text;
        needImage.sprite = sprite;
    }

    public void SetText(string text)
    {
        needValue.text = text;
    }
}
