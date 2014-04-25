using UnityEngine;
using System.Collections;

public class Enemy : CubbartController
{
	public Transform target;
	public float chaseSpeed = 3f;
	public Vector2 speed = new Vector2(10, 10); //speed of the object
	public Vector2 direction = new Vector2(-1, 0); // moving directions
	private Vector2 movement;
	
	
	void Update()
	{	
		transform.LookAt(target.position);
		transform.Rotate(new Vector3(0,-90, 0),Space.Self);//correcting the original rotation	
		
		//move towards the player
		if (Vector3.Distance(transform.position,target.position)>1f){//move if distance from target is greater than 1
			transform.Translate(new Vector3(chaseSpeed* Time.deltaTime,0,0) );
		}

		// 2 - Movement
		movement = new Vector2(
			speed.x * direction.x,
			speed.y * direction.y);
	}

	void FixedUpdate()
	{
		// Apply movement to the rigidbody
		rigidbody2D.velocity = movement;
	}
}	