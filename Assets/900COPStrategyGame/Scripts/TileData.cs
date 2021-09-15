using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileData
{

    private int tileValue; // see TileData param info 
    private string tileName; // see TileData param info 
    private string tileType; // see TileData param info 

    // You should be able to get tileValue by declaring the value of each separate tile
    public int TileValue
    {
        get
        {
            return tileValue;
        }

    }
    // same as TileValue, but for strings.
    private string TileName
    {
        get
        {
            return tileName;
        }

    }

    private string TileType
    {
        get
        {
            return tileType;
        }

        
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
        this.tileName = _tileName;
        this.tileValue = _tileValue;
        this.tileType = _tileType;

    }
    

}
