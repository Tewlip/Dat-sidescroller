using UnityEngine;
using System.Collections;

public class Player : CubbartController {
	

	public static float distanceTraveled;

	private bool isFalling = false; // is a variable only the player needs, which checks whether player is in the air or not.


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
		life = 1;
		jump = 200;
		speed = 4;

		distanceTraveled = transform.localPosition.x; //update on the distance Player has traveled since start

		targetSpeed = Input.GetAxisRaw("Horizontal")*speed;

		transform.position = new Vector3 (transform.position.x, transform.position.y, 0);// keeps player on the z-axis of virtual environment.

		//___________________________________________________________________________________

		transform.position = transform.position + new Vector3(speed,0,0) * Time.deltaTime;//automatic movement for the hero.
		
		//________________________________________________________________________________________

		if(Input.GetKey(KeyCode.D)) //The possible movement of the hero
			transform.position += new Vector3(0.2f,0,0);
		
		if(Input.GetKey(KeyCode.A))
			transform.position -= new Vector3(0.2f,0,0);

		if(Input.GetKey(KeyCode.S)) // testing to see if player wont stray from the z-axis
		transform.position += new Vector3(0,0,1);

		//_________________________________________________________________________________

		if(Input.GetKey(KeyCode.Space)&& isFalling == false)// checks of space is being pressed and isFalling is false
		{
			rigidbody.AddForce (new Vector3(0,jump,0)); // travels the value of variable jump along the y-axis. Remember Addforce is affected by the property values of rigidbody
		}
		isFalling = true;// sets isFalling to true, so a jumps can't be made continously. Remember to place it outside of if, due to how Unity reads the code.
	
		//_______________________________________________________________________________
	
	}

	void OnCollisionStay()
	{
		isFalling = false; // changes isFalling to false when in contact with an object
	}
}
