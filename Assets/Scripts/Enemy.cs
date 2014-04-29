using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
	public Transform prefab;
	public Transform target;
	public float chaseSpeed = 3f;
	public Vector3 patrol = new Vector3(10, 10, 0); //speed of the object
	public Vector3 direction = new Vector3(-1, 0, 0); // moving directions
	public Vector3 movement;
	
	
	void Update()
	{	
		transform.LookAt(target.position);
		transform.Rotate(new Vector3(0,-90, 0),Space.Self);//correcting the original rotation	
		
		//move towards the player
		if (Vector3.Distance(transform.position,target.position)>1f){//move if distance from target is greater than 1
			transform.Translate(new Vector3(chaseSpeed* Time.deltaTime,0,0) );
		}
		
		//Movement
		movement = new Vector3(
			patrol.x * direction.x,
			patrol.y * direction.y);
	}
	
	void FixedUpdate()
	{
		// Apply movement to the rigidbody
		rigidbody.velocity = movement;
	}
}	
