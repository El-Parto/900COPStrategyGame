using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;




[System.Serializable]
public class TileGenerator : MonoBehaviour
{

	[SerializeField] private TileInfo tileInfo;
	[SerializeField] private TileManager tileManager;
	[SerializeField] private GameObject building;


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



	public void InstantiateBuildingTile()
	{
		int objectInstatiatedID = UnityEngine.Random.Range(0, buildingPrefabs.Length);
		GameObject objectInstantiated = Instantiate(buildingPrefabs[objectInstatiatedID],)
	}
	public void InstantiateExerciseTile()
	{
		
	}
	public void InstantiateEntertainmentTile()
	{
		
	}
	public void InstantiateFeedingTile()
	{
		
	}
	public void InstantiateSleepingTile()
	{
		
	}



}
