using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LevelSelect : MonoBehaviour
{
	public Button[] lb;                                     //Array of Level Buttons
    public GameObject[] gems;                               //Array of Gem GameObjects
    // Start is called before the first frame update
    void Start()
    {
		int la = PlayerPrefs.GetInt("levelAt",3);           //player preference of starting elvel
		for(int i=0; i<lb.Length;i++)
		{
           
            if(la < (i * 4) + 3)                            //if player has not accessed a level, then that button is locked 
                lb[i].interactable=false; 
        }
        for (int i = 0; i < gems.Length; i++)
        {
            if (la>=(i*4)+7)
                gems[i].SetActive(true);                    //after player beats a boss, then a gem is added to the portal
        }
    }
}
