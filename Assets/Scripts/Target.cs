using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Target : MonoBehaviour
{
    // Start is called before the first frame update
    public float health = 50f;                                      //health of enemy
    public float maxhealth;                                         //max health of enemy
    public GameObject gem;                                          //gem appears if boss is defeated
    public bool isBoss;                                             //checks if enemy is a Boss
    public BossHealthBar bhb;                                       //accesses boss health bar
    void Start()
    {
        maxhealth = health;                                         //sets maxhealth to health
        if(isBoss)                                                  //if enemy is a boss, then boss health bar is set to health
        {
            bhb.SetMaxHealth(maxhealth);
        }      
    }
    public void TakeDamage(float amount)                            //enemy takes damage
    {
        health -= amount;
        if(isBoss)                                                  //if enemy is a boss, then boss health is set to health
        {
            bhb.SetHealth(health);
        }
        if (health <= 0f)                                           //enemy dies
        {
            if(isBoss)                                              //if enemy is a boss, then gem appears
            { 
                gem.SetActive(true);                                //gem appears
            }
            Die();
        }
    }
    public void Die()                                               //enemy disappears when health is depleted
    {
        Destroy(gameObject);
    }
}
