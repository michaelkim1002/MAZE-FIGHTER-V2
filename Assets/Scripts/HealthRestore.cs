using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthRestore : MonoBehaviour //similar to AmmoRestore script, but iterates players health
{
	public PlayerHealth hb;
    public int hpamount;
    public void GetHealth()
	{
		if(hb)
		{
			hb.RestoreHP(hpamount);
			Destroy(gameObject);
		}
	}
}
