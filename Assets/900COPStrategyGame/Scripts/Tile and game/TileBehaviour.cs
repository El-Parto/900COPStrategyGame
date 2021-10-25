using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class TileBehaviour : MonoBehaviour
{
	[SerializeField] private int adjacentDistance = 2;
	[SerializeField] private Vector3[] hexAngle;
	public List<string> adjacentTiles;

	[SerializeField] private Vector3 norEast = new Vector3(1, 0, 1),
		norWest = new Vector3(-1, 0, 1),
		southEast = new Vector3(-1, 0, 1),
		southWest = new Vector3(-1, 0, -1);

	private void Start()
	{
		hexAngle = new[]
		{
			Vector3.forward, norEast, Vector3.right, southEast, Vector3.back, southWest, Vector3.left,
			norWest, Vector3.up, Vector3.down,
		};
		//ChainReaction();
	}

	/*
	public void ChainReaction()
	{
		adjacentTiles.Clear();
		
		foreach (var angle in hexAngle)
		{
			RaycastHit hit;
			if (Physics.Raycast(transform.position, angle, out hit, adjacentDistance))
			{
				tempAccess = hit.collider.GetComponent<TileInfo>();
				//adjacentTiles.Add(tempAccess.TileType);
			}
		}
		AddScore();
	}
	*/

	public virtual void AddScore()
	{
		
	}

}

/*public class NonScoring : TileBehaviour
{
	
	public override void AddScore()
	{
		//tileScore = thisTile.TileValue;
	}
}

public class NextToSleep : TileBehaviour
{
	public override void AddScore()
	{
		for (int i = 0; i < adjacentTiles.Count; i++)
		{
			if (adjacentTiles[i] != "Sleeping")
				adjacentTiles.Remove(adjacentTiles[i]);
		}
		
		//tileScore = thisTile.TileValue + adjacentTiles.Count;
	}
}

public class NextToExercise : TileBehaviour
{
	public override void AddScore()
	{
		for (int i = 0; i < adjacentTiles.Count; i++)
		{
			if (adjacentTiles[i] != "Exercise")
				adjacentTiles.Remove(adjacentTiles[i]);
		}
		
		//tileScore = thisTile.TileValue + adjacentTiles.Count;
	}
}

public class CloseToFloor : TileBehaviour
{
	public int layerMask = 3;
	public override void AddScore()
	{
		Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit,Mathf.Infinity, layerMask);
		tileScore += (int)(3 - hit.distance);
	}
}

public class CloseToRoof : TileBehaviour
{
	public int layerMask = 3;
	public override void AddScore()
	{
		Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit,Mathf.Infinity, layerMask);
		tileScore += (int)hit.distance;
	}
}*/