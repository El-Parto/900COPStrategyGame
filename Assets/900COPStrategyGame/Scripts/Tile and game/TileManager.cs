using System.Collections;
using System.Collections.Generic;

using UnityEditorInternal;

using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class TileManager : MonoBehaviour
{
    public TileInfo tileInfo;

    [SerializeField] private GameObject tileObject;
    [SerializeField] private Material material;
  //  [SerializeField] private Text descriptionText;
  //  public Text tileNameText;
   // public Text tileTypeText;
    [SerializeField] private int value;
    public string createdTileName;
    public string createdTileDescription;
    public string createdtileType;
    
    // Start is called before the first frame update
    void Start()
    {
	    material = tileInfo.tileMaterial;
	    createdTileName = tileInfo.tileName;
	    createdTileDescription = tileInfo.tileType;
	    createdtileType = tileInfo.tileDescription;
	   
	    value = tileInfo.tileValue;
    }

    
}
