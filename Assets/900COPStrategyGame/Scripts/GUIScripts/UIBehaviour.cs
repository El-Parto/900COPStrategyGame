using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject tilePanel, optionsPanel;
    [SerializeField] private GameObject PanelStart, PanelEnd;
    [SerializeField] private GameObject opPanelStart, opPanelEnd;
    [SerializeField] private Image[] tiles;
    private bool on = true, opOn = true;
    private int selectedInt;
    private bool placing;
    
    public void Minimise()
    {
        on = !on;
        placing = false;
    }

    public void OptionsMenuMinimise()
    {
        opOn = !opOn;
        placing = false;
    }

    private void Update()
    {

        #region Slides

        if (on)
        {
            tilePanel.transform.position = new Vector3(PanelEnd.transform.position.x, Mathf.Lerp(
                tilePanel.transform.position.y,
                PanelStart.transform.position.y, Time.fixedDeltaTime));
        }
        else
        {
            tilePanel.transform.position = new Vector3(PanelEnd.transform.position.x, Mathf.Lerp(
                tilePanel.transform.position.y,
                PanelEnd.transform.position.y, Time.fixedDeltaTime));
        }

        if (opOn)
        {
            optionsPanel.transform.position = new Vector3(Mathf.Lerp(optionsPanel.transform.position.x,
                opPanelStart.transform.position.x, Time.fixedDeltaTime), opPanelEnd.transform.position.y);
        }
        else
        {
            optionsPanel.transform.position = new Vector3(Mathf.Lerp(optionsPanel.transform.position.x,
                opPanelEnd.transform.position.x, Time.fixedDeltaTime), opPanelEnd.transform.position.y);
        }


        #endregion
        
        

    }

    public void PickTile(int _selected)
    {
        on = false;
        selectedInt = _selected;
        placing = true;
    }

    public void PlaceTile()
    {
        GreyOut(tiles[selectedInt]);
    }
    
    private void Refresh()
    {
        foreach (Image tile in tiles)
        {
            tile.color = Color.white;   
        }
    }
    
    private void GreyOut(Image _image)
    {
        var imageColour = _image.GetComponent<Color>();
        imageColour = Color.gray;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
