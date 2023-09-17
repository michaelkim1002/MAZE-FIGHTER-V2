using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public void OnTriggerEnter()
    {
        Destroy(gameObject);            //Disappears when it hits an object
    }
    public void destroybullet()
    {
        Destroy(gameObject);
    }
}
