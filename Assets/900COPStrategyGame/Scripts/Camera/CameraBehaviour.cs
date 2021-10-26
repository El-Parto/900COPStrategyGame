using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cursor = UnityEngine.UIElements.Cursor;

public class CameraBehaviour : MonoBehaviour
{

    [SerializeField] private Camera camera;
    [SerializeField] private float camMax = 10, camMin = 10;
    [SerializeField] private float sensitivity = 10;
    [SerializeField] private Transform managerTransform;
    [SerializeField] private int altitude;
    private int placedTileLayer = 7, floorLayer = 4;
    [SerializeField] private GameObject tooltip;
    [SerializeField] private Text highlightedTile, tileType, description;
    public static RaycastHit hit;
    public static Vector3 hitLocation;
    private Ray ray;
    public static bool targetingGameSpace;

    private void Start()
    {
        ray = camera.ScreenPointToRay(Vector3.forward);
    }
    
    void Update()
    {
        #region inSceneTileToolTip
        if (Physics.Raycast(ray,out hit, Mathf.Infinity))
        {
            hitLocation = hit.collider.gameObject.transform.position;

            tooltip.SetActive(hit.collider.gameObject.layer != floorLayer);

            tooltip.transform.position = Input.mousePosition;
            Debug.Log(hit.collider.gameObject.layer);

            if(hit.collider.gameObject.layer != placedTileLayer)
            {
                highlightedTile.text = "Empty location:";
                tileType.text = "none";
                description.text = "You could build anything to appease his lordship here";
            }
            else
            {
                TileManager tempInfo = hit.collider.GetComponentInChildren<TileManager>();
 
                highlightedTile.text = tempInfo.createdTileName;
                description.text = "Type: " + tempInfo.createdTileDescription;
                tileType.text =  tempInfo.createdtileType;
            }
        }
        #endregion
    }

    private void FixedUpdate()
    {
        MoveCamera();
    }

    void MoveCamera()
    {
        float horizontalMovement = Input.GetAxis("Horizontal") * sensitivity;
        float verticalMovement = Input.GetAxis("Vertical") * sensitivity;
        Vector3 camPos = camera.transform.position;
        
        Mathf.Clamp(camPos.x, camMin, camMax);
        Mathf.Clamp(camPos.z, camMin, camMax);

        var position = managerTransform.position;
        camPos = new Vector3(position.x + horizontalMovement, transform.position.y, position.z +verticalMovement);
        camera.transform.position = camPos;
    }

    public void ChangeHeightLevel(bool up)
    {
        if (up && altitude < 3)
        {
            altitude++;
            managerTransform.position += new Vector3(0, 1, 0);
        }
        
        if (!up && altitude > 0)
        {
            altitude--;
            managerTransform.position += new Vector3(0, -1, 0);
        }
    }
    
}
