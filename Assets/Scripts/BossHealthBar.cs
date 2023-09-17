using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BossHealthBar : MonoBehaviour  //similar to PlayerHealthBar script, but it accesses to Boss enemy health
{
    public Slider slider; 
    public Text healt; 
    
    public void SetMaxHealth(float health) 
    {
        slider.value = health; 
        slider.value = health;
    }
    public void SetHealth(float health) 
    {
        slider.value = health;
    }
}
