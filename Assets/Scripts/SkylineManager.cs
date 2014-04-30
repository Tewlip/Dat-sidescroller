using UnityEngine;
using System.Collections.Generic;

public class SkylineManager : MonoBehaviour {

    public Transform prefab; //creates a field in which we can drop a prefab template of the platform object
	public int numberOfObjects; //used to control how many cubes need to fill the screen
	public float recycleOffset; //used to define how far behind the player that recycling of of cubes should occur
	public Vector3 startPosition, minSize, maxSize; //for denoting a point at which we start spawning cubes

	private Vector3 nextPosition; //used to keep track of where next cupe needs to spawn.
    private Queue<Transform> objectQueue; //The queue stores the template of platform, which is used for generating the level

	// Use this for initialization
	void Start () {
		objectQueue = new Queue<Transform> (numberOfObjects);
		for (int i = 0; i < numberOfObjects; i++) {
			objectQueue.Enqueue((Transform)Instantiate(prefab));

		}
		nextPosition = startPosition;
		for (int i = 0; i < numberOfObjects; i++) {
			Recycle();
		}
	
	}

	// Update is called once per frame
	void Update () {
		if(objectQueue.Peek().localPosition.x + recycleOffset < Player.distanceTraveled) { //we access the first item with peek and check if it's a given distance behind Player
            Recycle(); //if this statement is true, we recycle the object
		}
	
	}
    /// <summary>
    /// The recycle function is what controls the spawn mechanics of platforms and skylines.
    /// </summary>
	private void Recycle () { //seeing as initially placing platforms and recycling is the same, a method for Recycle can be used in both instances.
		Vector3 scale = new Vector3(
            Random.Range(minSize.x, maxSize.x), //randomizes the size of platforms within a given range for x, which is defined inside Unity
            Random.Range(minSize.y, maxSize.y), //same for y
            Random.Range(minSize.z, maxSize.z)); //same for z

		Vector3 position = nextPosition;
		position.x += scale.x * 0.5f;
		position.y += scale.y * 0.5f;

        Transform o = objectQueue.Dequeue(); //dequeue takes out the first item in the queue
		o.localScale = scale;
		o.localPosition = position;
		nextPosition.x += scale.x;
        objectQueue.Enqueue(o); //enqueue adds to the end of the queue
	}
}
