using UnityEngine;

public class Booster : MonoBehaviour {

    public Vector3 offset, rotationVelocity;
    public float recycleOffset, spawnChance;

	// Use this for initialization
	void Start () {
        gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.localPosition.x + recycleOffset < Player.distanceTraveled) {
            gameObject.SetActive(false);
            return;
        }
        transform.Rotate(rotationVelocity * Time.deltaTime);
	}

    public void SpawnIfAvailable(Vector3 position) {
        if (gameObject.activeSelf || spawnChance <= Random.Range(0f, 100f)) {
            return;
        }
        transform.localPosition = position + offset;
        gameObject.SetActive(true);
    }

    void OnTriggerEnter() {
        Player.AddBoost();
        gameObject.SetActive(false);
    }
}
