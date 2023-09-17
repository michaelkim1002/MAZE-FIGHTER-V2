using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public int maxhealth = 10;
    public int currenthealth;
    public PlayerHealthBar hb;                                              //accesses Health Bar UI
    public GameObject hurts;                                                //red screen that briefly appears when player takes damage
    float countdown; 
    public float delay = 0.2f;                                              //time for hurt screen to show
    public bool hurt;                                                       //checks if player just took damage
    public bool home;                                                       //checks of player is at home level
    void Start()                                                            //sets player health and countdown
    {
        if(home)                                                            //if home, then ammo annd health resets
        {
            currenthealth = maxhealth;
        }
        else                                                                //otherwise both values carry on
        {
            currenthealth = PlayerPrefs.GetInt("currentHealth", 10);
        }
       
        hb.SetMaxHealth(maxhealth);
        countdown = delay;
        hurt = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(home)
        {
            PlayerPrefs.SetInt("currentHealth", 10);
            hb.SetHealth(currenthealth);
        }
        else
        {
            PlayerPrefs.SetInt("currentHealth", currenthealth);
            hb.SetHealth(currenthealth);
        }
        
        if (currenthealth <= 0)                                             //if player dies, cursor is free and takes player to Game Over screen
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            PlayerPrefs.SetInt("currentHealth", maxhealth);
            PlayerPrefs.SetInt("currentAmmo", 50);
            SceneManager.LoadScene("Game Over");
        }
        if(hurt)                                                            //if player just got hurt, then hurt screen appears
        {
            Hs();
        }
        if (countdown <= 0)                                                 //how long hurt screen shows
        {
            hurts.SetActive(false);
            hurt = false;
            countdown = delay;
        }
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "bullet")                                 //takes damage if player is hit by bullet
        {
            TakeDamage(1);
            Destroy(col.gameObject);                                        //object disappears
        }
        if (col.gameObject.tag == "Bossbullet")                             //takes damage if player is hit by Bossbullet
        {
            TakeDamage(2);
            Destroy(col.gameObject);
        }
    }
    public void TakeDamage(int damage)                                      //updates health, updates health UI, and player is hurt
    {
        currenthealth -=damage;
        hb.SetHealth(currenthealth);
        hurt = true;
    }
    public void RestoreHP(int hp)                                           //restores health while updating UI
    {
        currenthealth += hp;
        if (currenthealth > maxhealth)
        {
            currenthealth = maxhealth;
        }
        hb.SetHealth(currenthealth);
    }
    public void Hs()                                                        //hurt screen pops up
    {
        hurts.SetActive(true);
        countdown -= Time.deltaTime;
    }
}
