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
    [SerializeField] private bool[] UIBools;
    
    [SerializeField] private Text[][] tilePickerToolTips;
    [SerializeField] private Text[] button1TT;
    [SerializeField] private Text[] button2TT;
    [SerializeField] private Text[] button3TT;
    [SerializeField] private Text[] button4TT;
    [SerializeField] private Text[] button5TT;
    
    [SerializeField] private Text finalScore;
    [SerializeField] private Image[] tiles;
    [SerializeField] private Sprite[] UIimages;
    [SerializeField] private Text[] buttonText;

    [SerializeField] private string[] buttonTextString;
    [SerializeField] private Text gameTimer, todayTiles, score;
    [SerializeField] private int maxGameLength = 7;
    [SerializeField] private float fastMove;
    [SerializeField] private GameObject gameManager;

    [SerializeField] private ButtonEvent[] events;
    [Tooltip("the ID of the tile in the button area")]public int[] tileID;
    public Button[] selectionButtons;
    public static int publicScore;
    public static bool gameOver;
    private int day = 1;
    [Tooltip("counts placed tiles")] public static int tileNo;
    private bool placing;
    public static bool endDay;
    
    private void Start()
    {
        tilePickerToolTips = new[] {button1TT, button2TT, button3TT, button4TT, button5TT };
        
        for (int i = 0; i < selectionButtons.Length; i++)
        {
            events[i] = selectionButtons[i].GetComponent<ButtonEvent>();
        }
        
        UIBools = new[] {true, true, false};
        fastMove = 3 * Time.fixedDeltaTime;
        RNGesus();
        UpdateToolTips();
        gameTimer.text = "Day: " + day + "/7";
        

    }

    private void Update()
    {

        #region Slides
        SmoothUIMovement(UIBools[0], tilePanel, PanelStart, PanelEnd, true);
        SmoothUIMovement(UIBools[1], optionsPanel, opPanelStart, opPanelEnd, false);
        SmoothUIMovement(UIBools[2], howToPlayPanel, htpStart, htpEnd, true);
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

    private void SmoothUIMovement(bool trigger, GameObject panel, GameObject start, GameObject end, bool vertical)
    {
        var endPos = end.transform.position;
        var startPos = start.transform.position;
        var vertPos = panel.transform.position.y;
        var horPos = panel.transform.position.x;
        
        if (vertical)
        {
            panel.transform.position = trigger 
                ? new Vector3(endPos.x, Mathf.Lerp(vertPos, startPos.y, fastMove)) 
                : new Vector3(endPos.x, Mathf.Lerp(vertPos, endPos.y, fastMove));
        }
        else
        {
            panel.transform.position = trigger
                ? new Vector3(Mathf.Lerp(horPos, startPos.x, fastMove), endPos.y)
                : new Vector3(Mathf.Lerp(horPos, endPos.x, fastMove), endPos.y);
        }

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

    #region Minimising Methods
    public void Minimise()
    {
        UIBools[0] = !UIBools[0];
    }

    public void OptionsMenuMinimise()
    {
        UIBools[1] = !UIBools[1];
        placing = false;
    }

    public void htpMinimise()
    {
        UIBools[2] = !UIBools[2];
    }
    #endregion

    public void PickTile(int _selected)
    {
        UIBools[0] = false;
        placing = true;
        GreyOut(tiles[_selected]);
        GameBehaviour.selectedTile = tileID[_selected];
        selectionButtons[_selected].enabled = false;
    }

    private void Refresh()
    {
        day++;
        gameTimer.text = "Day: " + day + "/" + maxGameLength;

        if (day > maxGameLength)
        {
            gameOver = true;
            foreach (var button in selectionButtons)
            {
                button.enabled = false;
            }
        }
        
        if (gameOver)
        {
            finalScore.text = publicScore.ToString();
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

        score.text = publicScore.ToString();
        UpdateToolTips();
    }

    void RNGesus()
    {
        for (int i = 0; i < tiles.Length; i++)
        {
            tileID[i] = UnityEngine.Random.Range(0, 11);
            tiles[i].sprite = UIimages[tileID[i]];
            buttonText[i].text = buttonTextString[tileID[i]];
        }
        endDay = false;
    }

    private void UpdateToolTips()
    {
        GameBehaviour tileRef = gameManager.GetComponent<GameBehaviour>();
        for (int i = 0; i < tilePickerToolTips.Length; i++)
        {
            var getName = tileRef.availableTiles[tileID[i]].GetComponent<TileManager>();
            tilePickerToolTips[i][0].text = getName.createdTileName;
            tilePickerToolTips[i][1].text = getName.createdtileType;
            tilePickerToolTips[i][2].text = getName.createdTileDescription;
            
        }
    }
    
    private void GreyOut(Image _image)
    {
        _image.color = Color.gray;
        UpdateToolTips();
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