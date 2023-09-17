using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerAmmo : MonoBehaviour
{
    public int maxammo = 50;                                            //max amount of ammo
    public int currentammo;                                             //player's current ammo
    public PlayerAmmoBar ab;                                            //access Ammo Bar UI
    public bool home;                                                   //checks of player is at home level
    void Start()                                                        //sets current ammo
    {
        if (home)                                                       //if home, then ammo annd health resets
        {
            currentammo = maxammo;
        }
        else                                                            //otherwise both values carry on
        {
            currentammo= PlayerPrefs.GetInt("currentAmmo", 50);
        }
        
        ab.SetMaxAmmo(maxammo);
    }
    void Update()
    {
        if (home)
        {
            PlayerPrefs.SetInt("currentAmmo", 50);
            ab.SetAmmo(currentammo);
        }
        else
        {
            PlayerPrefs.SetInt("currentAmmo", currentammo);
            ab.SetAmmo(currentammo);
        }
    }
    // Update is called once per frame
    public void UseAmmo(int use)                                        //uses up ammo while updating Bar UI
    {
        if(currentammo>0 && currentammo>=use)
        {
            currentammo -= use;
            ab.SetAmmo(currentammo);
        }
    }
    public void RestoreAmmo(int ammo)                                   //restores ammo while updating Bar UI
    {
        currentammo += ammo;
        if(currentammo >maxammo)
        {
            currentammo = maxammo;
        }
        ab.SetAmmo(currentammo);
    }
    public int AmmoAmount()                                             //Returns amount of ammo
    {
        return currentammo;
    }
}
