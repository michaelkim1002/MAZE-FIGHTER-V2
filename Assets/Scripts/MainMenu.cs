using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void PlayGame()
    {
        SceneManager.LoadScene("Home Level");           //loads hove level
    }
    public void BackToMain()
    {
        SceneManager.LoadScene("Main Menu");            //goes back to main menu
    }
    public void QuitGame()                              //quits game
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
}
