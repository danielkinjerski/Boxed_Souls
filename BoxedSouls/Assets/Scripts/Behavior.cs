using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]

public class Behavior : MonoBehaviour {
	
	
	/*public Transform target; //Target is your player
	EnemyMovement targetScript;
	
	public int maxHealth = 20;
    public float maxSpeed = 1;
    public float speed = 0;	
	float gravity = 1;
	
	
	bool test = true;	
	
	enum Deceleration{slow = 3, normal = 2, fast = 1};
	
	enum AIstates{idle, follow, attack}
	
	AIstates result = 0;
	
	CharacterController controller;
	
	Vector3 direction;
	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController>();
		targetScript = target.GetComponent<EnemyMovement>();
	
	}
	
	void seek()
	{
		
		//how fast your Ai will move		
		Deceleration deceleration = Deceleration.fast;
	
		//make sure the velocity does not exceed the max
		speed = Mathf.Min(speed, maxSpeed);
		
		//make sure the velocity does not exceed the max
		maxSpeed = Mathf.Max(speed,maxSpeed);
		
		// adjust pos, vel, fwd to seek to target
		direction = target.position - transform.position;
		direction.y = 0;
		
		speed = Mathf.Lerp(speed, maxSpeed, .01f);
        direction.Normalize();
		//Debug.DrawRay(transform.position, direction, Color.cyan);
        transform.forward = (transform.forward * 0.99f) + (direction * 0.01f);
        controller.Move((transform.forward * speed + Vector3.up * -gravity) * Time.deltaTime);		
	}
	
	
	void pursuit()
	{
		//calculation the distance
		float dx = target.position.x - transform.position.x; 
		float dy = target.position.y - transform.position.y;
		float dz = target.position.z - transform.position.z;
		float distance = Mathf.Sqrt(dx * dx + dy *  dy + dz * dz);
		
		Vector3 ToTarget = target.position - transform.position;
		
		//only pursuit if target is within "pursuit distance".
		//float PursuitDistanceSq = 25;
		
		//how fast your Ai will move		
		Deceleration deceleration = Deceleration.fast;
		
		float DecelerationTweaker = 0.9f;
			
		//calculate the speed required to reach the target
		float speed = distance / ((float)deceleration * DecelerationTweaker);
		
		//make sure the velocity does not exceed the max
		speed = Mathf.Min(speed, maxSpeed);
			
		float time = distance/speed;
		
		Vector3 posPursuit = target.position + target.forward *targetScript.speed * time;
		Debug.DrawRay(posPursuit, Vector3.up,Color.white);
		
		// adjust pos, vel, fwd to seek to target
		direction = posPursuit - transform.position;		
		direction.y = 0;
		
			
		
		speed = Mathf.Lerp(speed, maxSpeed, .01f);
        direction.Normalize();
		Debug.DrawRay(transform.position, direction, Color.cyan);
        transform.forward = (transform.forward * 0.99f) + (direction * 0.01f);
        controller.Move((transform.forward * speed + Vector3.up * -gravity) * Time.deltaTime);		
	}
	
	
	void evade()
	{
		//calculation the distance
		float dx = target.position.x - transform.position.x; 
		float dy = target.position.y - transform.position.y;
		float dz = target.position.z - transform.position.z;
		float distance = Mathf.Sqrt(dx * dx + dy *  dy + dz * dz);
		
		Vector3 ToTarget = target.position - transform.position;
		
		//only evade if target is within "panic distance".
		float PanicDistanceSq = 25;
		
		//speed of the AI
		Deceleration deceleration = Deceleration.fast;
		
		float DecelerationTweaker = .9f;
		//calculate the speed required to reach the target
		float speed = distance / ((float)deceleration * DecelerationTweaker);
			
		//make sure the velocity does not exceed the max
		speed = Mathf.Min(speed, maxSpeed);
		
		float time = distance/speed;
		
		Vector3 posEvade = target.position + target.forward *targetScript.speed * time;

		if (distance > PanicDistanceSq)
		{
			speed = speed * 0;
		}	
		
		// adjust pos, vel, fwd to seek to target
		direction = transform.position - posEvade;		
		direction.y = 0;

		
		speed = Mathf.Lerp(speed, maxSpeed, .01f);
        direction.Normalize();
		Debug.DrawRay(transform.position, direction, Color.cyan);
        transform.forward = (transform.forward * 0.99f) + (direction * 0.01f);
        controller.Move((transform.forward * speed + Vector3.up * -gravity) * Time.deltaTime);
	}
	
	
	// Update is called once per frame
	void Update () {
		//seek();	
		pursuit();
		//evade();	
	}*/
}
