using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public static float distanceTraveled; // variable overview
    public static int boosts;
    public float acceleration;
    public Vector3 jumpVelocity;
    public float gameOverY;
	public float speed;
	public GameObject laserPrefab;

    private bool touchingPlatform; // is a variable only the player needs, which checks whether player is in the air or not.
	
	// Use this for initialization
	void Start () { // Sets the value of boosts and distanceTraveled whenver the game starts
       
		boosts = 0;
        GUIManager.SetBoosts(boosts);//Updates GUI display of boosts value
        distanceTraveled = 0f;
	}
	
	// Update is called once per frame
	void Update () 
	{


		transform.position = new Vector3 (transform.position.x, transform.position.y, 0);// keeps player on the z-axis of virtual environment.
		distanceTraveled = transform.localPosition.x;
		
        
        //________________________________________Continuous movement towards right side_________________________________________

        transform.Translate(speed * Time.deltaTime, 0f, 0f);


		//_________________________________________Slowing Down__________________________________________

		
		if(Input.GetKey(KeyCode.A))
			transform.position -= new Vector3(0.05f,0,0);


		//_________________________________________Speed Up______________________________________________


		if(Input.GetKey(KeyCode.D))
			transform.position += new Vector3(0.2f,0,0);


		//_______________________________________Jumping________________________________________

		if(touchingPlatform && Input.GetButtonDown("Jump"))// checks of space is being pressed and isFalling is false
		{
            rigidbody.AddForce(jumpVelocity, ForceMode.VelocityChange); // travels the value of variable jump along the y-axis. Remember to use velocity as addforce can create some funky bugs with onCollision (velocity remains constant while addforce is += to the existing value).
			touchingPlatform = false;// sets isFalling to true, so a jumps can't be made continously. Remember to place it outside of if, due to how Unity reads the code.

		}

		//________________________________________________Attacking_______________________________


		if (Input.GetKeyDown("left ctrl") && boosts > 0) // sets a limit to attacks in relation to boosts when initiating attack
		    {
			Instantiate(laserPrefab, transform.position, Quaternion.identity); // Spawns laserPrefab from player's position.
			boosts -= 1; // substract 1 from variable boosts.
			GUIManager.SetBoosts(boosts);//Updates GUI display of boosts value 

		}

        //_____________________________________________Game Over___________________________________
       
		if (transform.localPosition.y < gameOverY) { //Load scene " menu" when player's y position is less than variable gameOverY.
			Application.LoadLevel("menu");
        } 
	} // end of update

    void FixedUpdate() {
        if (touchingPlatform) { // adds acceleration if in contact with platform's rigidbody.
            rigidbody.AddForce(acceleration, 0f, 0f, ForceMode.Acceleration);
        }
    }

	void OnCollisionStay(Collision interacter) // sets a condition of jump when colliding with objects.
	{
		if(interacter.contacts.Length > 0){ // If the array length of interacter.contacts becomes greater than 0, do the following:
			if(interacter.contacts[0].point.y < transform.position.y){// If the value of contact point is less than player's current position on the y-axis, do the following:
				touchingPlatform = true; // changes isFalling to false when in contact with an object
			}
		}
		//______________________________________________________________________________
	}
	

    public static void AddBoost() { 
        boosts += 1; // adds 1 to variable boosts.
		GUIManager.SetBoosts(boosts); //Updates GUI display of boosts value.
    }

}
