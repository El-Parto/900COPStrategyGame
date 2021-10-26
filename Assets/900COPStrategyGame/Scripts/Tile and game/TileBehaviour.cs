using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class TileBehaviour : MonoBehaviour
{
	[SerializeField] private int adjacentDistance = 2;
	[SerializeField] private Vector3[] hexAngle;
	[SerializeField] private Vector3[] upndown;
	[SerializeField] private Vector3 norEast = new Vector3(1, 0, 1),
		norWest = new Vector3(-1, 0, 1),
		southEast = new Vector3(-1, 0, 1),
		southWest = new Vector3(-1, 0, -1);
	

	private void Start()
	{
		hexAngle = new[] { Vector3.forward, norEast, Vector3.right, southEast, Vector3.back, southWest, Vector3.left,
			norWest, Vector3.up, Vector3.down};
		upndown = new[] {Vector3.up, Vector3.down};
		AddScore();
	}

	public void AddScore()
	{
		TileManager thisTile = GetComponent<TileManager>();
		ScoreMethod(thisTile.createdTileName);
	}

	private void AOEshot(string target, int baseScore, int bonus, Vector3[] shotAngle )
	{
		UIBehaviour.publicScore += baseScore;
				
		foreach (var angle in shotAngle)
		{
			if (Physics.Raycast(transform.position, angle, out var hit, adjacentDistance))
			{
				if (hit.collider.gameObject.GetComponent<TileManager>() == null)
				{
				}

				TileManager tempManager = hit.collider.gameObject.GetComponent<TileManager>();
				if (tempManager.createdtileType == target)
				{
					UIBehaviour.publicScore += bonus;
				}

			}
		}
	}

	private void AOEExclusion(string target, int baseScore, int bonus, Vector3[] shotAngle, bool name)
	{
		List<string> adjacentTypes = new List<string>();
		UIBehaviour.publicScore += baseScore;
		
		foreach (var angle in shotAngle)
		{
			if (Physics.Raycast(transform.position, angle, out var hit, adjacentDistance))
			{
				if (hit.collider.gameObject.GetComponent<TileManager>() == null)
				{
				}

				TileManager tempManager = hit.collider.gameObject.GetComponent<TileManager>();
				if (name)
				{
					if (tempManager.createdTileName == target)
					{
						adjacentTypes.Add(tempManager.createdTileName);
					}
				}
				else
				{
					if (tempManager.createdtileType == target)
					{
						adjacentTypes.Add(tempManager.createdtileType);
					}
				}

			}
		}

		if (!adjacentTypes.Contains(target))
		{
			UIBehaviour.publicScore += bonus;
		}
	}
	
	private void ScoreMethod(string tile)
	{
		switch (tile)
		{
			case "Cushioned Platform":
				AOEExclusion("Sleeping", 3, 1, upndown , false);
				break;
			
			case "Enclosed Bed":
				AOEExclusion("Enclosed Bed", 3, 1, upndown , true);
				break;
			
			case "Hammock":
				AOEshot("Sleeping", 2, 2, hexAngle);
				break;
			
			case "Automatic Feeder Platform":
				AOEshot("Exercise", 8, -2 , upndown);
				break;
			
			case "Cat Wheels":
				AOEshot("Sleeping", 8, -3, hexAngle);
				break;
			
			case "Ramp":
				AOEshot("Sleeping", 1, 2, upndown);
				break;
			
			case "Rope Bridge":
				AOEshot("Building", 3, 1, hexAngle);
				break;
			
			case "Screen":
				AOEshot("Entertainment", 2, 2, hexAngle);
				break;
			
			case "Scratching Post":
				AOEshot("Entertainment", 1, 2, hexAngle);
				break;
			
			case "Tessel Toy":
				UIBehaviour.publicScore += 4;
				break;
			
			case "Base Platform":
				UIBehaviour.publicScore += 1;
				break;
			
			case "Support":
				UIBehaviour.publicScore += 1;
				break;
		}
	}
}