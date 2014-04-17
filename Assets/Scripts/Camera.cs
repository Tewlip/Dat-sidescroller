using UnityEngine;
using System.Collections;

public class Camera : ObstacleBehavior {

	public Transform target; //set position of the camera according to the player's placement (remember to assign the player object to target parameter in unity)
	public float y = 1.0f;
	public float z = -15.0f;
	public float x = 1.0f;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		transform.position = Vector3.Lerp(transform.position, new Vector3 (target.transform.position.x + x, target.transform.position.y + y, target.transform.position.z + z), 2.0f *Time.deltaTime); //enables the camera to follow the player according to his position and is updated every Time.deltaTime * 2.

	}
}
