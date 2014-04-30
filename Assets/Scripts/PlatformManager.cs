using UnityEngine;
using System.Collections.Generic;

public class PlatformManager : MonoBehaviour {
	
	public Transform platformPrefab; //creates a field in which we can drop a prefab template of the platform object
	public int numberOfObjects; //used to control how many cubes need to fill the screen
	public float recycleOffset; //used to define how far behind the player that recycling of cubes should occur
	public Vector3 startPosition; //for denoting a point at which we start spawning cubes
	public Vector3 minSize, maxSize, minGap, maxGap; //Variables for the minimum and maximum size as well as the gaps between platforms
	public float minY, maxY; //Controls the max and minimum y levels within where platforms can be generated
    public Booster booster; //allows the plaform manager to know about Booster
    public Coins coin; //allows the plaform manager to know about Coins
    public Enemy Killer; //allows the plaform manager to know about Enemy
    public Material[] materials; //Array used for the different materials to have variety in platforms
    public PhysicMaterial[] physicMaterials; //Array used for the different physic materials for the various platforms

	
	private Vector3 nextPosition; //used to keep track of where next cube needs to spawn.
	private Queue<Transform> objectQueue; //The queue stores the template of platform, which is used for generating the level
	
	// Use this for initialization
	void Start () {
		objectQueue = new Queue<Transform> (numberOfObjects);
		for (int i = 0; i < numberOfObjects; i++) {
			objectQueue.Enqueue((Transform)Instantiate(platformPrefab));
		}
		nextPosition = startPosition;
		for (int i = 0; i < numberOfObjects; i++) {
			Recycle();
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		if(objectQueue.Peek ().localPosition.x + recycleOffset < Player.distanceTraveled) { //we access the first item with peek and check if it's a given distance behind Player
			Recycle(); //if this statement is true, we recycle the object
		}
		
	}
	
    /// <summary>
    /// The recycle function is what controls the spawn mechanics of platforms and skylines.
    /// </summary>
	private void Recycle () { //seeing as initially placing platforms and recycling is the same, a method for Recycle can be used in both instances.
		Vector3 scale = new Vector3(
			Random.Range (minSize.x, maxSize.x), //randomizes the size of platforms within a given range for x, which is defined inside Unity
			Random.Range (minSize.y, maxSize.y), //same for y
			Random.Range (minSize.z, maxSize.z)); //same for z
		
		Vector3 position = nextPosition;
		position.x += scale.x * 0.5f;
		position.y += scale.y * 0.5f;
        booster.SpawnIfAvailable(position); //spawns a booster after checking that one is available
		coin.SpawnIfAvailable(position); //same for coin
		Killer.SpawnIfAvailable(position); //same for killer
		
		Transform o = objectQueue.Dequeue(); //dequeue takes out the first item in the queue
		o.localScale = scale;
		o.localPosition = position;
        int materialIndex = Random.Range(0, materials.Length); //randomly picks one of the 3 platform types
        o.renderer.material = materials[materialIndex];
        o.collider.material = physicMaterials[materialIndex];
		objectQueue.Enqueue (o); //enqueue adds to the end of the queue

		nextPosition += new Vector3 (
			Random.Range (minGap.x, maxGap.x) + scale.x,
			Random.Range (minGap.y, maxGap.y),
			Random.Range (minGap.z, maxGap.z));

		if (nextPosition.y < minY) { //ensures that platforms are not generated below the minimum level
			nextPosition.y = minY + maxGap.y;
		}
		else if(nextPosition.y > maxY) { //ensures that platforms are not generated above the maximum level
			nextPosition.y = maxY - maxGap.y;
		}
	}
}
