using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerMove : MonoBehaviour
{
    public CharacterController controller;															//contols player
    public float speed = 12f;																		//speed of player movement
    public float gravity = -18.8f;																	//gravity value
    public Transform ground;																		//ground player is standing on
    public float groundDistance=0.4f;																//distance from player to ground
    public LayerMask gmask;																			//mask for ground
    public LayerMask vmask;																			//mask for void
	public LayerMask lmask;																			//mask for lava
    Vector3 velocity;																				//velocity of player movement
    bool isground;																					//Checks if player is standing on the ground
	bool isvoid;																					//Checks if player touches the void
    bool islava;																					//Checks if player is standing on lava
    public float jumph=3f;																			//jump height
	public PlayerHealth health;																		//accesses player's health
	public float lavaDamageTime = 0f;																//time it takes to take damage from lava again
	public Camera fpsCam;																			//camera is needed to pick up object
	public float pick= 10f;																			//distance from player to object player picks up
   
    // Update is called once per frame
    void Update()
    {
        isground=Physics.CheckSphere(ground.position,groundDistance,gmask); 
        isvoid = Physics.CheckSphere(ground.position, groundDistance, vmask); 
		islava = Physics.CheckSphere(ground.position, groundDistance, lmask); 

		if (isground&&velocity.y<0)																	//jumps up and then falls down
        {
            velocity.y=-2f;
        }
		if(isvoid)																					//if player falls to void, Game Over
		{
            Cursor.lockState = CursorLockMode.None;													//frees cursor
            Cursor.visible = true;
            SceneManager.LoadScene("Game Over");													//loads game over scene
        }
        if (islava && Time.time >= lavaDamageTime )													//takes damage when player is standing on lava door
        {
			lavaDamageTime = Time.time + 1f;
			health.TakeDamage(1);
        }

        float x=Input.GetAxis("Horizontal");														//movement is controlled with WASD keys
        float z=Input.GetAxis("Vertical");
        Vector3 move =transform.right*x+transform.forward*z;
        controller.Move(move*speed*Time.deltaTime);

        if(Input.GetButtonDown("Jump")&&(isground||islava))											//Jumps if space bar is pressed
        {
            velocity.y=Mathf.Sqrt(jumph*-2f*gravity);
        }

        velocity.y+=gravity*Time.deltaTime;
        controller.Move(velocity*Time.deltaTime);

		if(Input.GetButtonDown("Fire2"))															//Right click to pick up objects

		{
			PickUp();
		}
    }
	void PickUp()
	{
		RaycastHit hit;
		if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit,pick))
		{
			Debug.Log(hit.transform.name);
			HealthRestore target= hit.transform.GetComponent<HealthRestore>();
			if(target!=null)																		//picks up health potion to restore health
			{
				target.GetHealth();
			}         
			AmmoRestore target2 = hit.transform.GetComponent<AmmoRestore>();
			if(target2!=null)																		//picks up ammo cube to restore ammo
			{
				target2.GetAmmo();
			}
			Key target3= hit.transform.GetComponent<Key>();
			if(target3!=null)																		//picks up key to unlock door
			{
				target3.collect();
			}
            LevelDoor target4 = hit.transform.GetComponent<LevelDoor>();
            if (target4 != null)																	//accesses levels menu
            {
				target4.Levels();
            }
			Rune target5 = hit.transform.GetComponent<Rune>();
			if (target5 != null)																	//picks up gem to go to next scene
			{
				target5.nextlevel();
			}
		}
	}
}
