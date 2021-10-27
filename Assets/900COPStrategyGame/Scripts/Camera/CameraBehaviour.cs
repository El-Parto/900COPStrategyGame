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
    [SerializeField] private int maxHeight = 3, minHeight;
    
    public Text[] highlightedTile;
    public static RaycastHit hit;
    public static Vector3 hitLocation;
    private Ray ray;
    
    void FixedUpdate()
    {
        ray = camera.ScreenPointToRay(Input.mousePosition);
        
        #region inSceneTileToolTip
        if (Physics.Raycast(ray,out hit, Mathf.Infinity))
        {
            hitLocation = hit.collider.gameObject.transform.position;

            tooltip.SetActive(hit.collider.gameObject.layer != floorLayer);
            tooltip.transform.position = Input.mousePosition;

            if(hit.collider.gameObject.layer != placedTileLayer)
            {
                highlightedTile[0].text = "Empty location:";
                highlightedTile[1].text = "none";
                highlightedTile[2].text = "You could build anything to appease his lordship here";
            }
            else
            {
                TileManager tempInfo = hit.collider.GetComponentInChildren<TileManager>();
                highlightedTile[0].text = tempInfo.createdTileName;
                highlightedTile[1].text = "Type: " + tempInfo.createdtileType;
                highlightedTile[2].text = tempInfo.createdTileDescription;
            }
        }
        #endregion
        
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
        if (up && altitude < maxHeight)
        {
            altitude++;
            managerTransform.position += Vector3.up;
        }
        
        if (!up && altitude > minHeight)
        {
            altitude--;
            managerTransform.position += Vector3.down;
        }
    }
}
