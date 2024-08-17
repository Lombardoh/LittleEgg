using UnityEngine;
using TMPro;

public class NeedRowManager : MonoBehaviour
{
    public TMP_Text needText;
    public TMP_Text valueText;

    public void SetText(string needText, string valueText)
    {
        this.needText.text = needText;
        this.valueText.text = valueText;
    }
}
