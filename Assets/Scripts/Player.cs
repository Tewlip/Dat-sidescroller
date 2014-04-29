using UnityEngine;
using System.Collections;

public class Player : CubbartController {
	
	private bool isFalling = true; // is a variable only the player needs, which checks whether player is in the air or not.
	public static float distanceTraveled;
	public GameObject LaserPrefab;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{

		life = 1;
		jump = 10;
		speed = 4;

		targetSpeed = Input.GetAxisRaw("Horizontal")*speed;

		transform.position = new Vector3 (transform.position.x, transform.position.y, 0);// keeps player on the z-axis of virtual environment.
		distanceTraveled = transform.localPosition.x;
		//___________________________________________________________________________________

		transform.position = transform.position + new Vector3(speed,0,0) * Time.deltaTime;//automatic movement for the hero.


		//________________________________________________________________________________________


		if(Input.GetKey(KeyCode.D)) //The possible movement of the hero
			transform.position += new Vector3(0.2f,0,0);
		
		if(Input.GetKey(KeyCode.A))
			transform.position -= new Vector3(0.2f,0,0);

		if(Input.GetKey(KeyCode.S)) // testing to see if player wont stray from the z-axis
		transform.position += new Vector3(0,0,1);

		if (Input.GetKeyDown("left ctrl")) //Only fire once
		{
			Instantiate(LaserPrefab, transform.position, Quaternion.identity);
		}

		//_________________________________________________________________________________

		if(Input.GetKey(KeyCode.Space)&& isFalling == false)// checks of space is being pressed and isFalling is false
		{
			rigidbody.velocity = (new Vector3(0,jump,0)); // travels the value of variable jump along the y-axis. Remember to use velocity as addforce can create some funky bugs with onCollision (velocity remains constant while addforce is += to the existing value).
			isFalling = true;// sets isFalling to true, so a jumps can't be made continously. Remember to place it outside of if, due to how Unity reads the code.

		}

		//_______________________________________________________________________________
	
	}

	void OnCollisionStay(Collision interacter)
	{
		if(interacter.contacts.Length > 0){ // If the array length of interacter.contacts becomes greater than 0, do the following:
			if(interacter.contacts[0].point.y < transform.position.y){// If the value of contact point is less than player's current position on the y-axis, do the following:
				isFalling = false; // changes isFalling to false when in contact with an object
			}
		}
		//______________________________________________________________________________
	}

	void OnCollisionEnter(Collision Player)
	{

		if(Player.gameObject.name == "Enemy")
		{
			Destroy(gameObject);
		}

		if(Player.gameObject.name == "Enemy" && Input.GetKey(KeyCode.G))
		{

		}
	}
}
