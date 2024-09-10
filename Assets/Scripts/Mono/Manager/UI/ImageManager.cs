using UnityEngine;
using UnityEngine.UI;

public class ImageManager : MonoBehaviour
{
    private Image image;

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    public void SetImage(Sprite sprite)
    {
        image.sprite = sprite;
    }
}
