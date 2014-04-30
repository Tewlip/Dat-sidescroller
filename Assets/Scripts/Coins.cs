using UnityEngine;
using System.Collections;

public class Coins : Score {

	public Vector3 offset, rotationVelocity;
	public float recycleOffset, spawnChance;

	void Start(){
		gameObject.SetActive(false); // sets designated gameobject to inactive.
	}
	void OnTriggerEnter(Collider collision)
	{
		if(collision.gameObject.name == "Cubbart") // if gameobject "Cubbart" is in contact with designated object, add 1 to variable CoinCount and set object to inactive.
		{
			Score.CoinCount++;
			gameObject.SetActive(false);
		}

	}

	public void SpawnIfAvailable(Vector3 position) {
		if (gameObject.activeSelf || spawnChance <= Random.Range(0f, 100f)) { // checks if it is possible to instantiate gameobject.
			return;
		}
		transform.localPosition = position + offset;
		gameObject.SetActive(true); // sets designated object to active.
	}
}
