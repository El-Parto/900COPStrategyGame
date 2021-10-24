using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{

    [SerializeField] private Camera camera;
    [SerializeField] private float camMax = 10, camMin = 10;
    [SerializeField] private float sensitivity = 10;
    [SerializeField] private Transform managerTransform;
    [SerializeField] private int altitude;
    
    void Start()
    {
        
    }
    
    void Update()
    {

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
            managerTransform.position += new Vector3(0, 5, 0);
        }
        
        if (!up && altitude > 0)
        {
            altitude--;
            managerTransform.position += new Vector3(0, -5, 0);
        }
    }
    
}
