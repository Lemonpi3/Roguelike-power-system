using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class XPBar : MonoBehaviour
{
    Slider slider;

    void Start()
    {
       slider = GetComponent<Slider>();
    }

    public void UpdateBar(float xpCurrent,float xpMax)
    {
        if(xpMax <= 0) { xpMax = 1; }
        slider.value = xpCurrent/xpMax;
        // Debug.Log("current: "+xpCurrent+ "max: "+xpMax);

    }
}
