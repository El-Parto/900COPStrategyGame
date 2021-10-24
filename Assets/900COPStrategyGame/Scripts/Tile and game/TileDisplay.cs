using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[System.Serializable]
public class TileDisplay : MonoBehaviour
{
    private TileGenerator tileGen;
    private TileBehaviour tileBehaviour;
    

    public TileData whatIsThisTile = new TileData();
/*
    [Tooltip("Type of tile \n 0 = building \n 1 =  Entertainment \n 2 = Exercise \n 3 = Feeding \n 4 = ,Sleeping ")]
    [SerializeField] private int tileTypeID;
    [Tooltip("ID of the object based on what type it is.")]
    [SerializeField] private int tileObjectID;
    public int DefineTileName
    {

        set
        {
            tileTypeID = value;
            tileObjectID = value;

        }
    }
    */





    // Update is called once per frame
   private void Update()
    {
        
    }


   private void OnTriggerEnter(Collider trigger)
   {
       // if(trigger.tag = "tag name (Building, support, etc)
       // add score to combined score total in TileBehviour
       
   }

    // Gets tile based off of tile generator
   private void DetermineTileType()
    {
        
      //RaycastHit objInfo = Physics.Raycast()
     // tileGen.

    }
   
   //or on mouse click depending if GUI element or not.
}
