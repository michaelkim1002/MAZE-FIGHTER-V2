using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerHealthBar : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider slider;                           //Box image that will get updated in terms of length depending on the players health
    public Text healt;                              //Displays player's health
    
    // Update is called once per frame
    void Update()
    {
        hest();                                     //updates current health on UI
    }
    public void SetMaxHealth(int health)            //sets player's max health
    {
        slider.value = health;                      //length of slider updates depending on health
        slider.value = health;
    }
    public void SetHealth(int health)               //updates player's health
    {
        slider.value = health;
    }
    public void hest()                              //Function to display amount of health
    {
        healt.text = "Health: " +slider.value;
    }
}
