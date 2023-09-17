using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerAmmoBar : MonoBehaviour
{
    public Slider slider;
    public Text ammot;

    // Update is called once per frame
    void Update()
    {
        hest();                                 //updates current ammo on UI
    }
    public void SetMaxAmmo(int ammo)            //sets player's max ammo
    {
        slider.value = ammo;                    //length of slider updates depending on ammo
        slider.value = ammo;
    }
    public void SetAmmo(int ammo)               //updates player's ammo
    {
        slider.value = ammo;
    }
    public void hest()                          //Function to display amount of ammo
    {
        ammot.text = "Ammo: " + slider.value;

    }
}
