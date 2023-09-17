using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Rune : MonoBehaviour
{
    public int sceneload;                                           //preference of next scene
    public bool finalGem;                                           //last gem before final stage
    public bool endGem;                                             //gem that is collected to beat the game
    void Start()
    {
        sceneload = SceneManager.GetActiveScene().buildIndex+1;     //gets preference of next scene
    }
    public void nextlevel()
    {
        if(finalGem)                                                //checks to see if it's the final gem before the final stage so that the play has access to portal
        {
            SceneManager.LoadScene("Home Level");
        }
        else if (endGem)                                            //if player collects the ending gem, then end scene is loaded and the game is beaten
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            SceneManager.LoadScene("End Scene");
        }
        else                                                        //otherwise, the next scene is loaded
        {
            SceneManager.LoadScene(sceneload);
        }
		if(sceneload > PlayerPrefs.GetInt("levelAt"))               //updates the value of scene preference to the scene after the next scene
        {
			PlayerPrefs.SetInt("levelAt", sceneload);
		}
    }
}
