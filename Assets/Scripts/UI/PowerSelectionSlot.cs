using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PowerSelectionSlot : MonoBehaviour
{
    [SerializeField] private Image background;
    [SerializeField] private Image icon;
    [SerializeField] private Image iconBorder;

    [SerializeField] private TextMeshProUGUI powerName;
    [SerializeField] private TextMeshProUGUI powerDescription;

    [SerializeField] private PowerData power;
    private PowersAdquiredContainer powersAdquiredContainer;
    //TEMP
    void Start()
    {
        // UpdatePowerSlot(power,0);
        powersAdquiredContainer = FindObjectOfType<PowersAdquiredContainer>();
    }

    public void UpdatePowerSlot(PowerData _power,int rank)
    {
        if(_power is null){ return;}

        power = _power;
        background.color = power.powerSelectionColor;
        icon.sprite = power.icon;
        iconBorder.sprite = power.iconBorder;

        powerName.text = power.powerName;
        powerDescription.text = power.powerDescription.Length > rank ? power.powerDescription[rank] : power.powerDescription[power.powerDescription.Length-1];
    }

    public void SelectPower()
    {
        // Debug.Log(powerName.text + " Selected");
        powersAdquiredContainer.AddPower(power);
        powersAdquiredContainer.numberOfPowersToSelect -= 1;

        if(powersAdquiredContainer.numberOfPowersToSelect > 0){
            powersAdquiredContainer.RollPowers();
        }else{
            Time.timeScale = 1; //resets timeScale
            transform.parent.gameObject.SetActive(false);
        }
        
    }
}
