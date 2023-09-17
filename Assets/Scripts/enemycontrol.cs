using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class enemycontrol : MonoBehaviour
{
	public float delay =1f; //delay of when the enemy shoots again
	public float lookRadius=10f; //enemy interacts depending on if player is inside radius
	public float speed=50.0f; //speed of shot projectile
	float countdown; //countdown of when the enemy shoots again
	public Rigidbody pro; //projectile is Rigidbody object
	public Transform sp; //where the proectile is shot from
	Transform target; //enemy interacts with target
	NavMeshAgent agent; 
	public float bulcountdown; //current time of bullet traveling
	public float bullettravel; //how long a bullet travels

    void Start()
    {
		target=PlayerManager.instance.player.transform; //target is player
		agent=GetComponent<NavMeshAgent>(); 
		countdown = delay; //countdown is set to delay
		bulcountdown = bullettravel; //bulcountdown is set to bullettravel
	}

    // Update is called once per frame
    void Update()
    {
		float distance = Vector3.Distance(target.position,transform.position); //distance from player to enemy
		if(distance<=lookRadius)
		{
			agent.SetDestination(target.position);
			countdown-=Time.deltaTime;
			if(countdown<=0f) //if countdown is less than or equal to 0, then enemy shoots
			{
				Shoot(); //calls Shoot to shoot projectile
				countdown=delay; 
			}

			if(distance<agent.stoppingDistance)
			{
				FaceTarget(); //if player is in stopingDistance, the enemy faces target
			}
		}
    }
	void FaceTarget()
	{
		Vector3 direction = (target.position-transform.position).normalized; //direction enemy is facing
		Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x,0,direction.z)); //rotates until enemy is facing target
		transform.rotation = Quaternion.Slerp(transform.rotation,lookRotation,Time.deltaTime*5f);
	}
	void OnDrawGizmosSelected()
	{
		Gizmos.color=Color.red; 
		Gizmos.DrawWireSphere(transform.position,lookRadius);
	}
	void Shoot()
	{
		Rigidbody proj = (Rigidbody)Instantiate(pro, sp.position, sp.rotation); //Object is the projectile that is shot
		proj.velocity = sp.TransformDirection(new Vector3(0,0,speed)); //Direction and speed of the projectile
        bulcountdown -= Time.deltaTime; //bulcountdown iterates
        if (bulcountdown <= 0f)
        {
			Destroy(proj); //if bulcountdown is less than or equal to 0, then projectile disappears
            bulcountdown = bullettravel;
        }
    }
}
