using UnityEngine;
using System.Collections;

public class CubbartController : MonoBehaviour {
	
	//Section for Cubbart control variables.
	public float speed;	
	public float targetSpeed;
	public short temp;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


		/*Vector3 temp = Transform.position;
		temp.z = 0 ;
		Transform.position = temp;*/
	}

	/*void OnCollisionEnter(Collision collision){ //various collision codes enabling the objects to initiate a command when contacting the hero.
		
		if(collision.gameObject.name == "Enemy"){
			life -= 1;
		}
		else if( collision.gameObject.name == "Cylinder" && transform.position.y < 2f){ // the cylinder wont take any life from the hero if hero is above the value of 2 on the y axis.
			life -= 1;
		}
		
		if(life == 2){
			GameObject Life3Instance = GameObject.Find("Life3"); // three objects, each having a specific name which is destroyed depending on the value of variable life.
			if(Life3Instance != null)
				Destroy (Life3Instance);
		}
		if(life == 1){
			GameObject Life2Instance = GameObject.Find("Life2");
			if(Life2Instance != null)
				Destroy (Life2Instance);
		}
	}*/
}
