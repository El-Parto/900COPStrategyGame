using System.Collections;
using System.Collections.Generic;

using UnityEditorInternal;

using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class TileManager : MonoBehaviour
{
    public TileInfo tileInfo;

    public GameObject tileObject; // The object that needs to be instantiated(?)
    [SerializeField] private Material material; // the material it requires, as long as you have that set in the Scriptable object, it should auto fill.
    [SerializeField] private Text descriptionText;
    public Text tileNameText; // should be auto filled by Script' object
    public Text tileTypeText; // should be auto filled by Script' object
    [SerializeField] private int value; // should be auto filled by Script' object
    public string createdTileName; // should be auto filled by Script' object
    public string createdTileDescription; // should be auto filled by Script' object
    public string createdtileType; // should be auto filled by Script' object
    public int bonusModifier; // modifier if you want to include bonus scores. feel free to change to float if need be.

    // Start is called before the first frame update
    void Start()
    {
	    // the auto filling process.
	    material = tileInfo.tileMaterial;
	    createdTileName = tileInfo.tileName;
	    createdTileDescription = tileInfo.tileDescription;
	    createdtileType = tileInfo.tileType;
	   
	    value = tileInfo.tileValue;
	    
	    // tileInfo = the scriptable object. Remember this is OBJECT based and refers to each individual object relative to it's game object reference.
	    // e.g. base platform Game object has this script on it, that needs a reference to a scriptable object also named
	    // base platform, so then the values in the sepcific scriptable object is called. And only the object reference.

	    // tile UI text references here
	    tileNameText.text = createdTileName;
	    descriptionText.text = createdTileDescription;
	    tileTypeText.text = createdtileType;
    }

}
