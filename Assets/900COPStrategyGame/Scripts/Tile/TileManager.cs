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
    [SerializeField] private TextMeshProUGUI descriptionText;
    public TextMeshProUGUI tileNameText;
    public TextMeshProUGUI tileTypeText;
    [SerializeField] private int value;
    
    // Start is called before the first frame update
    void Start()
    {
	    material = tileInfo.tileMaterial;
	    tileNameText.text = tileInfo.tileName;
	    tileTypeText.text = tileInfo.tileType;
	    descriptionText.text = tileInfo.tileDescription;
	    value = tileInfo.tileValue;
    }

    
}
