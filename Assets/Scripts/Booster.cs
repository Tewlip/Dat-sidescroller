using UnityEngine;

public class Booster : MonoBehaviour {

    public Vector3 offset, rotationVelocity; //offset determines how high above a platform the booster object is placed, rotationVelocity determine the rotation speed
    public float recycleOffset, spawnChance;

	// Use this for initialization
	void Start () {
        gameObject.SetActive(false); // Sets the designated gameobject to inactive.
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.localPosition.x + recycleOffset < Player.distanceTraveled) { // Gameobject is inactive if its current position + recycleOffset value is less than player position
            gameObject.SetActive(false);
            return;
        }
        transform.Rotate(rotationVelocity * Time.deltaTime); // Allows for rotation of the gameobject.
	}

    /// <summary>
    /// SpawnIfAvailable allows the booster to spawn when a check for availability returns true
    /// </summary>
    /// <param name="position"></param>
    public void SpawnIfAvailable(Vector3 position) { 
        if (gameObject.activeSelf || spawnChance <= Random.Range(0f, 100f)) { //checks whether the gameObject is active or not
            return;
        }
        transform.localPosition = position + offset; //sets the position of the booster object
        gameObject.SetActive(true);
    }

    void OnTriggerEnter() { // When player triggers gameobject, Addboost is called and gameobject is set to inactive.
        Player.AddBoost();
        gameObject.SetActive(false);
    }
}
