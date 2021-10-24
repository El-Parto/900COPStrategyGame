using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;




[System.Serializable]
public class TileGenerator : MonoBehaviour
{


   // private string[] tileNames;
    private static string[] tileTypes= {"Building","Entertainment","Exercise", "Feeding","Sleeping"};
    //public TileData[] tileDatas = new TileData[5];
    
    // building tiles
    public TileData basicPlatform = new TileData("Basic Platform", tileTypes[0], 1);
    public TileData support = new TileData("Support", tileTypes[0], 1);
	    
    // excersise tiles
    public TileData catWheel = new TileData("Cat Wheel", tileTypes[2], 1);
    public TileData ramp = new TileData("Ramp", tileTypes[2], 1);
    public TileData ropeBridge = new TileData("Rope Bridge", tileTypes[2], 1);
	    
    // entertainment tiles
    public TileData iScreen = new TileData("iScreen", tileTypes[1], 1);
    public TileData iTassel = new TileData("Tassel Toy", tileTypes[1], 1);
    public TileData scratchPost = new TileData("Scratching Post", tileTypes[1], 1);
	    
	    
    //sleeping tiles
    public TileData enclosedBed = new TileData("Enclosed Bed", tileTypes[4], 1); 
    public TileData cushyPlatform = new TileData("Cushioned Platform", tileTypes[4], 1);
	    
    // feeding tile
    public TileData autoFeed = new TileData("Automatic Feeder Platform", tileTypes[3], 1);

    public List<TileData> tiles = new List<TileData>();
    // want to be able to determine what type of object this is upon loading it in


    public List<TileData> Tiles
    {
	    get => tiles;
	    set => tiles = value;
    }
    

    // Start is called before the first frame update
    void Start()
    {
	    InitialiseTile();
    }
    

    //function for generating the appropriate tiles. public for now
    
    public void InitialiseTile()
    {

	    
    }
    
    
    
}
