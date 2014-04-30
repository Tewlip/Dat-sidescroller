using UnityEngine;

public class Booster : MonoBehaviour {

    public Vector3 offset, rotationVelocity;
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

    public void SpawnIfAvailable(Vector3 position) {
        if (gameObject.activeSelf || spawnChance <= Random.Range(0f, 100f)) {
            return;
        }
        transform.localPosition = position + offset;
        gameObject.SetActive(true);
    }

    void OnTriggerEnter() { // When player triggers gameobject, Addboost is called and gameobject is set to inactive.
        Player.AddBoost();
        gameObject.SetActive(false);
    }
}
