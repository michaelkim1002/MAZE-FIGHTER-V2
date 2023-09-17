using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
public class nextlevel : MonoBehaviour
{
	public int sceneLoad;											//variable for scene preference
    void Start()
    {
		sceneLoad = SceneManager.GetActiveScene().buildIndex+1;		//Gets scene preference of next scene
    }
	public void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag =="Player")							//If object touches player, it takes them to the next scene/level
		{
			SceneManager.LoadScene(sceneLoad);						//loads next scene
			if(sceneLoad > PlayerPrefs.GetInt("levelAt"))			//updates the value of scene preference to the scene after the next scene
			{
				PlayerPrefs.SetInt("levelAt", sceneLoad); 
			}
		}
	}
} 