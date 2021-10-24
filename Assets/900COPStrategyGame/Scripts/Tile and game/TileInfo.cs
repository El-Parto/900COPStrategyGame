using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// As long as This script is in the project, you may right click and open the menu like how you would create a game object
/// select "Tile"
/// Then it creates a object for you to input values to.
/// </summary>
[CreateAssetMenu(fileName = "New Tile", menuName = "Tile")]
public class TileInfo : ScriptableObject
{
    // Each scriptable object is it's own separate object 
    // E.G. "Basic platform" would be it's own Scriptable Object.
    // The values below are what this scriptable object requires to be filled out on the Scriptable Object itself.
    
    // The idea is that after filling in all the information "TileManager" would then reference these values based on 
    // what you indicate on the Scriptable object
    
    public int tileValue; // THe value of the tile that is called by the scriptable object
    public string tileName; // name of the tile
    public string tileDescription; // description
    public string tileType; //type
    public Material tileMaterial; //you get the idea.
    
    // if you want to change the value of what the object is, change the value found in the tile scriptable object
    
    // if you want to change the bonus value, check the tile manager script on the game object.



}
