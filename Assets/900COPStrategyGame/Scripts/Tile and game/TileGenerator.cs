using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;




[System.Serializable]
public class TileGenerator : MonoBehaviour
{

	[SerializeField] private TileInfo tileInfo;
	[SerializeField] private TileManager tileManager;
	
	[SerializeField] private Transform spawnPoint; // the position in which it spawns


	// the following is Gameobject arrays separated by type.
	// they are filled in manually in the scene.
	// they should already be filled in in the scene, but check just to make sure.
	public GameObject[] buildingPrefabs; // if inspector empty, grab objects from > prefabs / tiles / Building
	public GameObject[] exercisePrefabs; // if inspector empty, grab objects from > prefabs / tiles / excersise
	public GameObject[] entertainmentPrefabs; // if inspector empty, grab objects from > prefabs / tiles / entertainment
	public GameObject[] feedingPrefabs; // if inspector empty, grab objects from > prefabs / tiles / Feeding
	public GameObject[] sleepingPrefabs; // if inspector empty, grab objects from > prefabs / tiles / Sleeping


	// The plan: generate a random tile based off of type. 
	void Start() { }



	// Start is called before the first frame update


	/// <summary>
	/// Instantiates a random tile (gameobject) in the buildingPrefab array.
	/// spawnPoint is the transform.position of where you'd like to spawn it. 
	/// </summary>
	public void InstantiateBuildingTile()
	{
		int objectInstatiatedID = UnityEngine.Random.Range(0, buildingPrefabs.Length); // arbitrary value used to determin which game object spawns
		GameObject objectInstantiated = Instantiate(buildingPrefabs[objectInstatiatedID], spawnPoint);
	}
	
	/// <summary>
	/// Instantiates a random tile (gameobject) in the exercisePrefab array.
	/// spawnPoint is the transform.position of where you'd like to spawn it. 
	/// </summary>
	public void InstantiateExerciseTile()
	{
		int objectInstatiatedID = UnityEngine.Random.Range(0, exercisePrefabs.Length); // arbitrary value used to determin which game object spawns
		GameObject objectInstantiated = Instantiate(exercisePrefabs[objectInstatiatedID], spawnPoint);
	}

	/// <summary>
	/// Instantiates a random tile (gameobject) in the entertainmentPrefab array.
	/// spawnPoint is the transform.position of where you'd like to spawn it. 
	/// </summary>
	public void InstantiateEntertainmentTile()
	{
		int objectInstatiatedID = UnityEngine.Random.Range(0, entertainmentPrefabs.Length); // arbitrary value used to determin which game object spawns
		GameObject objectInstantiated = Instantiate(entertainmentPrefabs[objectInstatiatedID], spawnPoint);
	}
	
	/// <summary>
	/// Instantiates a random tile (gameobject) in the feedingPrefab array.
	/// spawnPoint is the transform.position of where you'd like to spawn it. 
	/// </summary>
	public void InstantiateFeedingTile()
	{
		int objectInstatiatedID = UnityEngine.Random.Range(0, feedingPrefabs.Length); // arbitrary value used to determin which game object spawns
		GameObject objectInstantiated = Instantiate(feedingPrefabs[objectInstatiatedID], spawnPoint);
	}
	
	/// <summary>
	/// Instantiates a random tile (gameobject) in the sleepingPrefab array.
	/// spawnPoint is the transform.position of where you'd like to spawn it. 
	/// </summary>
	public void InstantiateSleepingTile()
	{
		int objectInstatiatedID = UnityEngine.Random.Range(0, sleepingPrefabs.Length); // arbitrary value used to determin which game object spawns
		GameObject objectInstantiated = Instantiate(sleepingPrefabs[objectInstatiatedID], spawnPoint);
	}



}
