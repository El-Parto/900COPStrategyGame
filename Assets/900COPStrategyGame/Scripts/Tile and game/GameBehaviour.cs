using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class GameBehaviour : MonoBehaviour
{ 
    private int playerHeight;
    private GameObject[][] Hitboxes;
    [SerializeField] private GameObject[] bases, groundBoxes, level1boxes, level2boxes , level3boxes;
    [SerializeField] private bool placing;
    [SerializeField] private GameObject Ghost, PlacedTile;
    [SerializeField] private int[] gameTimer;
    [SerializeField] private int builtZone = 7;
    [SerializeField] private GameObject[] availableTiles;
    public static int selectedTile;

    private void Start()
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

       Ghost.transform.position = CameraBehaviour.hitLocation;

       if (!placing || !Input.GetKeyDown(KeyCode.Mouse0)) return;

       #region placing a tile

       if (GhostShenanigans.available)
       {
           PlacedTile = Instantiate(availableTiles[selectedTile], CameraBehaviour.hit.collider.gameObject.transform.position, 
               Quaternion.AngleAxis(180, Vector3.up));
           var target = CameraBehaviour.hit.collider.gameObject;
           target.tag = availableTiles[selectedTile].tag;
           target.layer = builtZone;
           MarchOfTime();
           
           placing = false;
       }
       #endregion
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

       UIBehaviour.tileNo = gameTimer[0];
       
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
