using UnityEngine;
using System.Collections;

public class Player : CubbartController {
	

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		targetSpeed = Input.GetAxisRaw("Horizontal")*speed;

		//Physics.gravity = Vector3(-1.0,0,0);

		transform.position = new Vector3 (transform.position.x, transform.position.y, 0);

		transform.position = transform.position + new Vector3(speed,0,0) * Time.deltaTime;//automatic movement for the hero.
		
		if(Input.GetKey(KeyCode.D)) //The possible movement of the hero
			transform.position += new Vector3(0.2f,0,0);
		
		if(Input.GetKey(KeyCode.A))
			transform.position -= new Vector3(0.2f,0,0);

		if(Input.GetKey(KeyCode.S))
		transform.position += new Vector3(0,0,1);

		if(Input.GetKey(KeyCode.Space))
			transform.position += new Vector3(0,0.1f,0);

	}
}
