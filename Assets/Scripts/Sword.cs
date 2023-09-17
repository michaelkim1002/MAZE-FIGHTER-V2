using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour                                                                      //similar to HandGun Script, but involves animation
{
    // Start is called before the first frame update
    public float damage = 1f;
    public float range = 100f;
    public float fireRate = 15f;
    public Camera fpsCam;
    public ParticleSystem muzzleflash;
    public PlayMode swing;                                                                              //needed for animation of sword
    private float nextTimeToFire = 0f;
 
    // Update is called once per frame
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            GetComponent<Animation>().Play(swing);
            Shoot();         
        }    
    }
    void Shoot()
    {
        muzzleflash.Play();
        RaycastHit hit;
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                if (target.tag == "bullet"|| target.tag == "Bossbullet")                                //if sword blocks bullet, bullet disappears
                {
                    target.Die();
                }
                else
                {
                    target.TakeDamage(damage);
                }
            }
        }
    }
}
