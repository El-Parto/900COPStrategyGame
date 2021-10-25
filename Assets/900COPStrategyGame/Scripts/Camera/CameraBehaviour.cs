using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
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
    private int layerMask = 5 << 6;
    [SerializeField] private GameObject tooltip;
    [SerializeField] private Text description;
    public Text highlightedTile;
    public static RaycastHit hit;
    public static Vector3 hitLocation;
    private Ray ray;
    private Ray UIray;

    private void Start()
    {
        ray = camera.ScreenPointToRay(Vector3.forward);
    }


    void Update()
    {
        ray = camera.ScreenPointToRay(Input.mousePosition);

        #region inSceneTileToolTip
        if (Physics.Raycast(ray,out hit, Mathf.Infinity, layerMask))
        {
            hitLocation = hit.collider.gameObject.transform.position;
            
            tooltip.SetActive(true);
            tooltip.transform.position = Input.mousePosition;

            if (hit.collider.CompareTag("TileFloorBase"))
            {
                highlightedTile.text = "Empty location:";
                description.text = "You could build anything to appease his lordship here";
            }
            
            if(hit.collider.CompareTag("PlacedTile"))
            {
                TileInfo tempInfo = hit.collider.gameObject.GetComponent<TileInfo>();
                description.text = tempInfo.tileDescription;
            }
        }
        else
        {
            tooltip.SetActive(false);
        }
        #endregion

        #region CanvasToolTip
        
        

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
