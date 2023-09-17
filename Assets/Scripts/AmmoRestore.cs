using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoRestore : MonoBehaviour 
{
	public PlayerAmmo playerammo;					//Access to Player's ammo
	public int ammoamount;							//Amount of ammo restored
	public void GetAmmo()							//When called, amount of ammo gets restored by ammoamount
	{
		if(playerammo)
		{
            playerammo.RestoreAmmo(ammoamount);		//Calls RestoreAmmo function to increase current ammo
			Destroy(gameObject);					//uses up ammo object, therefore making the object disappear

		}
	}
}
