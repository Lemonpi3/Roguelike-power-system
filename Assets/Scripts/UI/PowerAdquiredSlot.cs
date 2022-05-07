using UnityEngine;
using UnityEngine.UI;

public class PowerAdquiredSlot : MonoBehaviour
{
    public void Initialize(PowerData powerData)
    {
        Image icon = GetComponent<Image>();
        icon.sprite = powerData.icon;
    }

    public void UpdateSlot(PowerData powerData)
    {
        Image icon = GetComponent<Image>();
        icon.sprite = powerData.icon;
    }
}
