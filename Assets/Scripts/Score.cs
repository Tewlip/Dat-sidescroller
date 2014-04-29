using UnityEngine;
using System.Collections;

public class Score : Player {

	public static int CoinCount;
	public float score;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{

		score = distanceTraveled + (100 * CoinCount); // sets score to the position of Cubbart.

		GameObject.Find("Score").guiText.text = score.ToString("score is: " + "0"); // Sets GUI text Score to string "Score is: " and the value of variable score. Remember to use "0" instead of variable "score" to remove decimals.
	}


}