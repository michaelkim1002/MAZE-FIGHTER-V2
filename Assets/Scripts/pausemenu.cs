using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class pausemenu : MonoBehaviour
{
	public static bool GameIsPaused;								//checks if game is paused
	public GameObject pmui;											//UI of pausemenu
	public GameObject w;											//weapon the player is holding
	public GameObject b;
	public GameObject door;
	public GameObject finaldoor;
	public bool homelevel;
	public LevelDoor ld;											//access to LevelDoor

    
    void Update()
    {
		if (Input.GetKeyDown(KeyCode.Escape))						//pauses if esc is pressed
        {
			if(ld.isLevelMenu())									//Player can't 'pause' if level menu is up
			{
				if(GameIsPaused)									//checks if game is paused
				{
					Cursor.lockState=CursorLockMode.Locked;
					Cursor.visible = false;
					Resume();
				}
				else
				{
					Cursor.lockState=CursorLockMode.Confined;		//cursor is free
					Pause();										//Pause is called
				}
			}
        }
    }
	public void Resume()
    {
		GameIsPaused = false;										//game is not paused
        Time.timeScale = 1f;										//frames can move
		pmui.SetActive(false);										//ui of pause menu disappears
        w.SetActive(true);
		b.SetActive(true);
        if(homelevel)
        {
			door.SetActive(true);
			finaldoor.SetActive(true);
        }
		Cursor.lockState=CursorLockMode.Locked;
		Cursor.visible=false;
	}
   public void Pause() 
    {
		GameIsPaused = true;										//Game is paused
		Time.timeScale = 0f;
		pmui.SetActive(true);										//Pause Menu UI pops up
		w.SetActive(false);											//Weapon disappears
		b.SetActive(false);											//Bar UI disappears
		if (homelevel)
		{
			door.SetActive(false);
			finaldoor.SetActive(false);
		}
		Cursor.lockState=CursorLockMode.None;						//cursor is free
		Cursor.visible=true;
    }
	public void LoadMenu()
	{
		PlayerPrefs.SetInt("currentHealth", 10);
		PlayerPrefs.SetInt("currentAmmo", 50);
		SceneManager.LoadScene("Main Menu");						//goes back to main menu
		Time.timeScale=1f;
		GameIsPaused=false;
	}
	public void QuitGame()											//quits game
	{
		Debug.Log("QUIT!");
		Application.Quit();
	}
}