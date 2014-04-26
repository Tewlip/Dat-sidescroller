using UnityEngine;
using System.Collections;

public class Score :Player {

	private float score;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		score = 34;

		//score += GameObject.Cubbart  new Vector3(x,0,0);

		//score += GameObject("Cubbart");

		GameObject.Find("Score").guiText.text = score.ToString("Score is: "+ score); // Sets GUI text Score to string "Score is: " and the value of variable score.
	}
}
