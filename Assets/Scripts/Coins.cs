using UnityEngine;
using System.Collections;

public class Coins : Score {
	

	void OnTriggerEnter(Collider collision)
	{
		if(collision.gameObject.name == "Cubbart")
		{
			Score.CoinCount++;
			Destroy(gameObject);
		}

	}
}
