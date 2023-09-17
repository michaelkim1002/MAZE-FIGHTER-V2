using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LevelDoor : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool GameIsPaused;                                //checks if game is paused
    public GameObject levels;                                       //levels screen
    public GameObject w;                                            //weapon the player is holding
    public GameObject b;                                            //Ammo and Health Bars
    public static bool ws;                                          //check if level menu is up
    void Update()
    {
        ws = false;
    }
    public void Resume()
    {
        levels.SetActive(false);
        ws = true;
        Time.timeScale = 1f;                                        //Frames can move
        GameIsPaused = false;
        Cursor.lockState = CursorLockMode.Locked;                   //cursor is locked
        Cursor.visible = false;
        w.SetActive(true);                                          //Weapon pops up
        b.SetActive(true);                                          //Bar UI pops up
    }
    public void Begin()
    {
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        GameIsPaused = false;
        Cursor.visible = false;
        w.SetActive(true);
        b.SetActive(true);
    }
    public void Pause()
    {
        GameIsPaused = true;
        Time.timeScale = 0f;                                        //Frames are paused
        levels.SetActive(true);                                     //level menu pops up
        w.SetActive(false);                                         //Weapon disappears
        b.SetActive(false);                                         //Bar UI disappears
        Cursor.lockState = CursorLockMode.None;                     //cursor is visible and free
        Cursor.visible = true;
    }
    public void QuitGame()
    {
        Application.Quit();                                         //quits the game
    }
    public void Levels()
    {
        ws = false;
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.Confined;
        Pause();
    }
    public void ChangeScene(int scene)
    {
        ws = true;
        Time.timeScale = 1f;
        GameIsPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        w.SetActive(true);
        b.SetActive(true);
        SceneManager.LoadScene(scene);                              //loads specific level
    }
    public bool isLevelMenu()
    { 
        if(ws == false)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
 