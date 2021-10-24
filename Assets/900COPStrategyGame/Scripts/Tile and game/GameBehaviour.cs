using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBehaviour : MonoBehaviour
{ 
    private int playerHeight;
   private GameObject[][] Hitboxes;
   [SerializeField] private GameObject[] groundBoxes, level1boxes, level2boxes;
   
    void Start()
    {
        Hitboxes = new[] {groundBoxes, level1boxes, level2boxes};
    }
    

    public void ToggleHitBoxes()
    {
        for (int i = 0; i < playerHeight; i++)
        {
            if (i <= playerHeight)
            {
                foreach (GameObject hitbox in Hitboxes[i])
                {
                    hitbox.SetActive(true);
                }
            }
            else
            {
                foreach (GameObject hitbox in Hitboxes[i])
                {
                    hitbox.SetActive(false);
                }
            }
        }
    }
}
