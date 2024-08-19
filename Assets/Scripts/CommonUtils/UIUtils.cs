using UnityEngine;
using UnityEngine.UI;

public static class UIUtils
{
    public static void TogglePanel(Transform panel, bool status)
    {
        if (panel == null) return;
        panel.gameObject.SetActive(status);
    }

    public static void FitImageToPanel(Transform panel, Sprite sprite)
    {
        if (!panel.TryGetComponent<Image>(out Image needPanelImage)) return;
        needPanelImage.sprite = sprite;
    }
}
