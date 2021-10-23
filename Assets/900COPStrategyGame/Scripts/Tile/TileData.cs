using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class TileData
{

    //private static string[] tileTypes= {"Building","Entertainment","Exercise", "Feeding","Sleeping"};
    [SerializeField]private int tileValue; // see TileData param info 
    [SerializeField]private string tileName; // see TileData param info 
    [SerializeField]private string tileType; // see TileData param info 

    // You should be able to get tileValue by declaring the value of each separate tile
    public int TileValue
    {
        get { return tileValue; }

        set { tileValue = value; }
    }

    // same as TileValue, but for strings.
    public string TileName
    {
        get { return tileName; }
        set { tileName = value; }
    }

    public string TileType
    {
        get { return tileType;}
        set { tileType = value; }
    }

    
    
/// <summary>
/// empty constructor
/// </summary>
    public TileData()
    {
        
    }
/// <summary>
///  Constructor that provides the basis for creating a Tile. needs tileName, tileType and a tileValue
/// </summary>
/// <param name="_tileName">The name of the tile</param>
/// <param name="_tileType">What type of tile it is</param>
/// <param name="_tileValue">what the tile is worth</param>
public TileData(string _tileName,string _tileType , int _tileValue )
    {
        this.TileName = _tileName;
        this.TileValue = _tileValue;
        this.TileType = _tileType;

    }

    

}
