using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;
using Image = UnityEngine.UI.Image;

public class UIBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject tilePanel, optionsPanel, howToPlayPanel, gameOverPanel;
    [SerializeField] private GameObject PanelStart, PanelEnd;
    [SerializeField] private GameObject opPanelStart, opPanelEnd;
    [SerializeField] private GameObject htpStart, htpEnd;
    [SerializeField] private Text finalScore;
    [SerializeField] private Image[] tiles;
    [SerializeField] private int[] tileID;
    [SerializeField] private Sprite[] UIimages;
    [SerializeField] private Text[] buttonText;
    [SerializeField] private Button[] selectionButtons;
    [SerializeField] private string[] buttonTextString;
    [SerializeField] private Text gameTimer, todayTiles, score;
    public static int publicScore;
    public static bool gameOver;
    private bool on = true, opOn = true, htp;
    private int day = 1;
    public static int tileNo;
    private bool placing;
    public static bool endDay;
    
    private void Start()
    {
        RNGesus();
        gameTimer.text = "Day: " + day + "/7";
    }

    private void Update()
    {
        #region Slides
        if (on)
        {
            tilePanel.transform.position = new Vector3(PanelEnd.transform.position.x, Mathf.Lerp(
                tilePanel.transform.position.y, PanelStart.transform.position.y, Time.fixedDeltaTime));
        }
        else
        {
            tilePanel.transform.position = new Vector3(PanelEnd.transform.position.x, Mathf.Lerp(
                tilePanel.transform.position.y, PanelEnd.transform.position.y, Time.fixedDeltaTime));
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
        
        if (htp)
        {
            howToPlayPanel.transform.position = new Vector3(htpEnd.transform.position.x, Mathf.Lerp(
               howToPlayPanel.transform.position.y, htpStart.transform.position.y, Time.fixedDeltaTime));
        }
        else
        {
            howToPlayPanel.transform.position = new Vector3(htpEnd.transform.position.x, Mathf.Lerp(
                howToPlayPanel.transform.position.y, htpEnd.transform.position.y, Time.fixedDeltaTime));
        }


        #endregion

        if (placing && Input.GetKeyDown(KeyCode.Escape))
        {
            placing = false;
            Refresh();
        }
        
        TileCounter();
        score.text = publicScore.ToString();

        if (!endDay) return; 
        Refresh();
        RNGesus();
    }

    private void TileCounter()
    {
        if (tileNo != 0)
            todayTiles.text = "Tiles placed:" + tileNo + " / 3";
        else
        {
            todayTiles.text = "A new day has dawned, Tiles re-rolled!";
        }
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

    public void htpMinimise()
    {
        htp = !htp;
    }

    public void PickTile(int _selected)
    {
        on = false;
        placing = true;
        GreyOut(tiles[_selected]);
        GameBehaviour.selectedTile = tileID[_selected];
        selectionButtons[_selected].enabled = false;
    }

    private void Refresh()
    {
        day++;
        gameTimer.text = "Day: " + day + "/7";
        Debug.Log(tileNo);

        if (gameOver)
        {
            finalScore.text = String.Empty;
            gameOverPanel.SetActive(true);
            
        }
        
        foreach (Image tile in tiles)
        {
            tile.color = Color.white;   
        }

        for (int i = 0; i < selectionButtons.Length; i++)
        {
            selectionButtons[i].enabled = true;
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
        endDay = false;
    }
    
    private void GreyOut(Image _image)
    {
        _image.color = Color.gray;
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