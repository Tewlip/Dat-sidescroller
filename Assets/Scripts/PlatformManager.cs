﻿using UnityEngine;
using System.Collections.Generic;

public class PlatformManager : MonoBehaviour {
	
	public Transform prefab;
	public int numberOfObjects; //used to control how many cubes need to fill the screen
	public float recycleOffset; //used to define how far behind the player that recycling of of cubes should occur
	public Vector3 startPosition; //for denoting a point at which we start spawning cubes
	public Vector3 minSize, maxSize, minGap, maxGap; 
	public float minY, maxY;
    public Booster booster;
    public Material[] materials;
    public PhysicMaterial[] physicMaterials;
	
	private Vector3 nextPosition; //used to keep track of where next cupe needs to spawn.
	private Queue<Transform> objectQueue;
	
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
		if(objectQueue.Peek ().localPosition.x + recycleOffset < Player.distanceTraveled) {
			Recycle();
		}
		
	}
	
	private void Recycle () { //seeing as initially placing platforms and recycling is the same, a method for Recycle can be used in both instances.
		Vector3 scale = new Vector3(
			Random.Range (minSize.x, maxSize.x),
			Random.Range (minSize.y, maxSize.y),
			Random.Range (minSize.z, maxSize.z));
		
		Vector3 position = nextPosition;
		position.x += scale.x * 0.5f;
		position.y += scale.y * 0.5f;
        booster.SpawnIfAvailable(position);
		
		Transform o = objectQueue.Dequeue();
		o.localScale = scale;
		o.localPosition = position;
        int materialIndex = Random.Range(0, materials.Length);
        o.renderer.material = materials[materialIndex];
        o.collider.material = physicMaterials[materialIndex];
		objectQueue.Enqueue (o);

		nextPosition += new Vector3 (
			Random.Range (minGap.x, maxGap.x) + scale.x,
			Random.Range (minGap.y, maxGap.y),
			Random.Range (minGap.z, maxGap.z));

		if (nextPosition.y < minY) {
			nextPosition.y = minY + maxGap.y;
		}
		else if(nextPosition.y > maxY) {
			nextPosition.y = maxY - maxGap.y;
		}
	}
}
