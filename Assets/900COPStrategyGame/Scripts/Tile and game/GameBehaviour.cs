using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.Windows.WebCam;

public class GameBehaviour : MonoBehaviour
{ 
    private int playerHeight;
    private GameObject[][] Hitboxes;
    [SerializeField] private GameObject[] bases, groundBoxes, level1boxes, level2boxes , level3boxes;
    [SerializeField] private bool placing;
    [SerializeField] private GameObject Ghost, PlacedTile;
    [SerializeField] private int[] gameTimer;
    [SerializeField] private LayerMask buildableZone = 7;
    [SerializeField] private GameObject[] availableTiles;
    [SerializeField] private int selectedTile;
    void Start()
    {
        gameTimer = new int[2];
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

       if (placing && Input.GetKeyDown(KeyCode.Mouse0))
       {
           Instantiate(availableTiles[selectedTile], Ghost.transform.position, Quaternion.identity);
       }
       
       Ghost.transform.position = CameraBehaviour.hitLocation;
   }

   void MarchOfTime()
   {
       gameTimer[0]++;
       
       if (gameTimer[0] > 2)
       {
           gameTimer[0] = 0;
           gameTimer[1]++;
           UIBehaviour.endDay = true;
       }

       if (gameTimer[1] > 7)
       {
           UIBehaviour.gameOver = true;
       }
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

    void Activity(int height)
    {
        height = playerHeight + 1;
        
        for (int i = 0; i < Hitboxes.Length; i++)
        {
            foreach (GameObject hitBox in Hitboxes[i])
            {
                if (i <= height)
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
