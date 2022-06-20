using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public abstract class StatusBar : MonoBehaviour
{
   Slider slider;

    void Start()
    {
       slider = GetComponent<Slider>();
    }

    public virtual void UpdateBar(float currentAmount,float maxAmount)
    {
        if(maxAmount <= 0) { maxAmount = 1; }
        slider.value = currentAmount/maxAmount;
    }
}
