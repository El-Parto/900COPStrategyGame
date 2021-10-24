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
    [SerializeField] private int[] tileID;
    [SerializeField] private Sprite[] UIimages;
    [SerializeField] private Text[] buttonText;
    [SerializeField] private string[] buttonTextString;
    private bool on = true, opOn = true;
    private int selectedInt;
    private bool placing;

    private void Start()
    {
        RNGesus();
    }

    public void Minimise()
    {
        on = !on;
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

        if (placing && Input.GetKeyDown(KeyCode.Escape))
        {
            placing = false;
            Refresh();
        }
    }

    public void PickTile(int _selected)
    {
        on = false;
        selectedInt = _selected;
        placing = true;
        GreyOut(tiles[_selected]);
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

    void RNGesus()
    {
        for (int i = 0; i < tiles.Length; i++)
        {
            tileID[i] = UnityEngine.Random.Range(0, 9);
            tiles[i].sprite = UIimages[tileID[i]];
            buttonText[i].text = buttonTextString[tileID[i]];
        }
    }
    
    private void GreyOut(Image _image)
    {
        var imageColour = _image.GetComponent<Color>();
        imageColour = Color.gray;
    }
    
    

    public void Deselect()
    {
        placing = false;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
