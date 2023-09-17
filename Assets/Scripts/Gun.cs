using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    // Start is called before the first frame update
    public float damage = 1f; 
    public float range = 100f; 
    public float fireRate = 15f;
    public Camera fpsCam;                                                                           //needs player cam to look with weapon
    public ParticleSystem muzzleflash;                                                              //plays a video effect of gun shooting
    private float nextTimeToFire = 0f;                                                              //delay of player shooting again
    public PlayerAmmo playerammo;                                                                   //access to player's ammo
    public int useammo;                                                                             //amount of ammo used to shoot gun
    // Update is called once per frame
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;                                                   //locks cursor on screen for weapon shooting
        Cursor.visible = false;
    }
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)                                //if mouse button is held down, then gun is shooting
        {
            if(playerammo)
            {
                if(playerammo.AmmoAmount()>=useammo)                                                //if current ammo is less than required ammo to use, then player can't shoot
                {
                    nextTimeToFire = Time.time + 1f/fireRate;                                       //time it takes for player to shoot again depending on fire rate
                    Shoot();                                                                        //calls Shoot function
                    playerammo.UseAmmo(useammo);                                                    //calls UseAmmo function to use up ammo
                } 
            } 
        }
    }
    void Shoot()
    {
        muzzleflash.Play();                                                                         //plays video effecrt
        RaycastHit hit;
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))    //accesses if cursor is on target
        {
            Target target = hit.transform.GetComponent<Target>();                                   //target to take damage from gun
            if (target != null)
            {
                target.TakeDamage(damage);                                                          //if cursor is on target, then target takes damage
            }
        }
    }
}
