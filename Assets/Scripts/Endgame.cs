using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Endgame : MonoBehaviour
{
    public SpriteRenderer shieldGenerator;
    public Scrollbar climbLocation;
    public Image scrollHandle;
    
    public Toggle noneClimb;
    public Toggle parkClimb;
    public Toggle fullClimb;

    public GameObject locationChecks;
    public Toggle canSpinToggle;
    public Toggle rotControlToggle;
    public Toggle posControlToggle;
    public Toggle initLineToggle;
    public Toggle brickedToggle;

    public Button commentsButton;
    public Button backButton;

    private bool justChanged = false; // Used when the value of a toggle is modified in its 
                                      // onValueChanged listener, to prevent stackoverflow 
    private bool isLocation;

    // Start is called before the first frame update
    void Start() {
        noneClimb.onValueChanged.AddListener(noneClicked);
        parkClimb.onValueChanged.AddListener(parkClicked);
        fullClimb.onValueChanged.AddListener(fullClicked);

        commentsButton.onClick.AddListener(nextScene);
        backButton.onClick.AddListener(prevScene);

        isLocation = Constants.getRoleName() == "Location";

        bool switchColor = (isLocation && !Variables.currentLocation.red) || (!isLocation && !Variables.currentMatch.red);
        shieldGenerator.sprite = Resources.Load<Sprite>("Images/" + (switchColor ? "Blue" : "Red") + "ShieldGenerator");
        if(switchColor) {
            scrollHandle.color = new Color(79/255f, 90/255f, 178/255f);
        }

        if(!isLocation) {
            locationChecks.SetActive(false);
        }
    }

    void noneClicked(bool value) {
        if(justChanged) { return; }
        justChanged = true;
        noneClimb.isOn = true;
        fullClimb.isOn = false;
        parkClimb.isOn = false;
        justChanged = false;
    }

    void parkClicked(bool value) {
        if(justChanged) { return; }
        justChanged = true;
        noneClimb.isOn = false;
        fullClimb.isOn = false;
        parkClimb.isOn = true;
        justChanged = false;
    }

    void fullClicked(bool value) {
        if(justChanged) { return; }
        justChanged = true;
        noneClimb.isOn = false;
        fullClimb.isOn = true;
        parkClimb.isOn = false;
        justChanged = false;
    }

    void nextScene() {
        if(isLocation)
            Variables.currentLocation.climbPos = (int)(climbLocation.value * 4);
        else
            Variables.currentMatch.climbPos = (int)(climbLocation.value * 4);

        int climbType = 2;
        if(noneClimb.isOn) 
           climbType = 0;
        else if(parkClimb.isOn) 
            climbType = 1;
        
        if(isLocation)
            Variables.currentLocation.climbType = climbType;
        else
            Variables.currentMatch.climbType = climbType;

        if(isLocation) {
            Variables.currentLocation.initLine = initLineToggle.isOn;
            Variables.currentLocation.canSpin = canSpinToggle.isOn;
            Variables.currentLocation.rotControl = rotControlToggle.isOn;
            Variables.currentLocation.posControl = posControlToggle.isOn;
            // Variables.currentLocation.bricked = brickedToggle.isOn;
        }

        SceneManager.LoadScene("Comments");
    }

    void prevScene() {
        if(isLocation)
            SceneManager.LoadScene("Location");
        else
            SceneManager.LoadScene("GamePieces");
    }
}
