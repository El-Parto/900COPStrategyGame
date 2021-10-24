using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.WebCam;

public class GameBehaviour : MonoBehaviour
{ 
    private int playerHeight;
    private GameObject[][] Hitboxes;
    [SerializeField] private GameObject[] bases, groundBoxes, level1boxes, level2boxes , level3boxes;
    [SerializeField] private bool placing;
    [SerializeField] private GameObject Ghost, PlacedTile;
    [SerializeField] private int newLayer = 7;
   void Start()
    {
        Hitboxes = new[] {bases, groundBoxes, level1boxes, level2boxes, level3boxes};
        Activity(playerHeight);
        Ghost.SetActive(false);
    }

   private void Update()
   {
       
       if (Input.GetKeyDown(KeyCode.Escape))
       {
           placing = false;
           Ghost.SetActive(false);
       }

       if (!placing)
       {
           Ghost.transform.position = new Vector3(0, 30, 0);
           return;
       }
       
       Ghost.transform.position = CameraBehaviour.hitLocation;


       if (!Input.GetKeyDown(KeyCode.Mouse0) || CameraBehaviour.hit.collider.gameObject.layer == newLayer) return;
       
       var camTarget = CameraBehaviour.hit.collider.gameObject;
       Instantiate(PlacedTile, Ghost.transform.position, Quaternion.identity);
       placing = false;
           
           
       camTarget.tag = "PlacedTile";
       camTarget.layer = newLayer;
   }

   public void ToggleHitBoxes(bool up)
    {
        if (up && playerHeight < 3)
            playerHeight++;

        if (!up && playerHeight > 0)
            playerHeight--;
    
        Activity(playerHeight);
    }

    public void Placing()
    {
        placing = true;
        Ghost.SetActive(true);
    }

    public void PlaceBuilding()
    {
        
    }

    void Activity(int height)
    {
        for (int i = 0; i < Hitboxes.Length; i++)
        {
            foreach (GameObject hitBox in Hitboxes[i])
            {
                if (i <= playerHeight + 1)
                {
                    hitBox.SetActive(true);
                }
                else
                {
                    hitBox.SetActive(false);
                }
            }
        }

    }
}
