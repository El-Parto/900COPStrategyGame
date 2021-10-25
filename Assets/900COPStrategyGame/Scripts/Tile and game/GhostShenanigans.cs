using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostShenanigans : MonoBehaviour
{
    private MeshRenderer tempHit;
    private MeshRenderer rend;
    [SerializeField] private Material[] materials;
    private bool available;
    private float downDistance = 1;

    private void Start()
    {
        rend = GetComponent<MeshRenderer>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Ghost"))
            OpenFire();
    }

    private void OnCollisionExit()
    {
        rend.material = materials[1];
    }

    private void OpenFire()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, downDistance))
        {
            if((hit.collider.gameObject.CompareTag("TowerBase") || hit.collider.gameObject.CompareTag("PlacedTile"))
               && !gameObject.CompareTag("PlacedTile"))
            {
                available = true;
            }
            else
            {
                available = false;
            }
        }
        
        rend.material = available ? materials[0] : materials[2];
    }
}
