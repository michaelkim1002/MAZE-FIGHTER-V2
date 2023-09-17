using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour //This Scipt is needed for interaction with enemycontrol script
{
   #region Singleton
	public static PlayerManager instance;
	void Awake()
	{
		instance=this;
	}
	#endregion
	public GameObject player;
}
