using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBar : MonoBehaviour
{
    [SerializeField] Slider slider;
    
    public void SetMaxEnergy(float energy)
    {
        slider.value = energy;
        slider.maxValue = energy;
    }

    public void setEnergy(float energy)
    {
        slider.value = energy;
    }
}
