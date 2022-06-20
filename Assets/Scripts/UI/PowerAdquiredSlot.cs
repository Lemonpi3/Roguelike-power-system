using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PowerAdquiredSlot : MonoBehaviour
{
    private TextMeshProUGUI powerRank;
    private PowerData power;
    private Image icon;
    
    public void Initialize(PowerData powerData)
    {
        power = powerData;
        icon = GetComponent<Image>();
        powerRank = GetComponentInChildren<TextMeshProUGUI>();
        icon.sprite = powerData.icon;
        powerRank.text = "1";
    }

    public void UpdateSlot(PowerData powerData, Power _power)
    {
        Debug.Log("UPDATED "+ _power.rank);
        icon.sprite = powerData.icon;
        powerRank.text = $"{_power.rank}";
    }
}
