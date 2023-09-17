using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandGun : MonoBehaviour                                    //similar to Gun script, except it requires to click to shoot, not hold down
{
    // Start is called before the first frame update
    public float damage = 1f;
    public float range = 100f;
    public float fireRate = 15f;
    public Camera fpsCam;
    public ParticleSystem muzzleflash;
    private float nextTimeToFire = 0f;
    public PlayerAmmo playerammo;
    public int useammo;
    // Update is called once per frame
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire) //if mouse button is pressed, then HandGun is used
        {
            if (playerammo)
            {
                if (playerammo.AmmoAmount() >= useammo)
                {
                    nextTimeToFire = Time.time + 1f / fireRate;
                    Shoot();
                    playerammo.UseAmmo(useammo);
                }
            }
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
                target.TakeDamage(damage);
            }
        }
    }
}
