﻿using UnityEngine;
using System.Collections;

public class Runner : MonoBehaviour {

	public static float distanceTraveled; //used to keep track of how far the player has traveled

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (5f * Time.deltaTime, 0f, 0f);
		distanceTraveled = transform.localPosition.x;
	}
}
