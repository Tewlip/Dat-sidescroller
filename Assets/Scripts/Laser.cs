using UnityEngine;
using System.Collections;

public class Laser : MonoBehaviour {

	public float laserSpeed = 30.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		float amtToMove = laserSpeed * Time.deltaTime;
		transform.Translate (Vector3.right * amtToMove);
	
	}
}
