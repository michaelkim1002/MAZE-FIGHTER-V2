using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitching : MonoBehaviour
{
    public int selectedWeapon = 0;
    void Start()
    {
        SelectWeapon();                                                         //starts off with first weapon of arsenal
    }
    // Update is called once per frame
    void Update()                                                               //if scroll wheel is used, then it updates the weapon the player is holding
    {
        int prevWeapon = selectedWeapon;
        if(Input.GetAxis("Mouse ScrollWheel")>0f)
        {
            if (selectedWeapon >= transform.childCount - 1)
                selectedWeapon = 0;
            else
                selectedWeapon++;
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (selectedWeapon <= 0)
                selectedWeapon = transform.childCount - 1;
            else
                selectedWeapon--;
        }
        if(prevWeapon != selectedWeapon)
        {
            SelectWeapon();
        }
        if(Input.GetKeyDown(KeyCode.Alpha1))                                    //if 1 is pressed, then current weapon is 0
        {
            selectedWeapon = 0;
            SelectWeapon();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount >=1)       //if 2 is pressed, then current weapon is 1
        {
            selectedWeapon = 1;
            SelectWeapon();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && transform.childCount >= 2)      //if 3 is pressed, then current weapon is 2
        {
            selectedWeapon = 2;
            SelectWeapon();
        }
    }
    void SelectWeapon()                                                         //selects the current weapon
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {
            if (i == selectedWeapon)
                weapon.gameObject.SetActive(true);                              //weapon is pulled out
            else
                weapon.gameObject.SetActive(false);                             //weapon disappears
            i++;           
        }            
    }
}
