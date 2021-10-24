using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostShenanigans : MonoBehaviour
{
    private MeshRenderer tempHit;
    private MeshRenderer rend;
    [SerializeField] private Material[] materials;
    private bool supported;
    public LayerMask layerMask = 6;

    private void Start()
    {
        rend = GetComponent<MeshRenderer>();
        
    }

    private void OnCollisionEnter(Collision other)
    {
        RaycastHit hit;
        Physics.Raycast(transform.position, Vector3.down, out hit, 1, layerMask);

        supported = hit.collider.gameObject.layer != 6;

        if (gameObject.CompareTag("TileFloorBase"))
        {
            if(other.gameObject.CompareTag("Untagged"))
                rend.material = materials[0];
        }
        
        if(!gameObject.CompareTag("TileFloorBase") || !supported)
        {
            if(other.gameObject.CompareTag("Untagged"))
                rend.material = materials[2];
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if(other.gameObject.CompareTag("Untagged"))
            rend.material = materials[1];
    }
}
