using UnityEngine;
using System.Collections;

public class Coins : Score {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision collision)
	{
		if(collision.gameObject.name == "Cubbart")
		{
			score += 100.0f;
			Destroy(gameObject);
		}

	}
}
