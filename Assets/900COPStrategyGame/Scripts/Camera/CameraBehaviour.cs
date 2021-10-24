using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

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

    void Update()
    {
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
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
            else
            {
                //describe the building based on what building is present and points that building gives
                /*TileInfo tempInfo = hit.collider.gameObject.GetComponent<TileInfo>();
                description.text = tempInfo.tileDescription;*/
            }
        }
        else
        {
            tooltip.SetActive(false);
        }
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
