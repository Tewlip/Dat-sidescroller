using UnityEngine;
using System.Collections;

public class Coins : Score {

	public Vector3 offset, rotationVelocity;
	public float recycleOffset, spawnChance;

	void Start(){
		gameObject.SetActive(false);
	}
	void OnTriggerEnter(Collider collision)
	{
		if(collision.gameObject.name == "Cubbart")
		{
			Score.CoinCount++;
			gameObject.SetActive(false);
		}

	}

	public void SpawnIfAvailable(Vector3 position) {
		if (gameObject.activeSelf || spawnChance <= Random.Range(0f, 100f)) {
			return;
		}
		transform.localPosition = position + offset;
		gameObject.SetActive(true);
	}
}
