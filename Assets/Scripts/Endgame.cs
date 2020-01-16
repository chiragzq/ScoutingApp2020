using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Endgame : MonoBehaviour
{
    public Scrollbar climbLocation;
    
    public Toggle noneClimb;
    public Toggle parkClimb;
    public Toggle fullClimb;

    public Button commentsButton;
    public Button backButton;

    private bool justChanged = false; // Used when the value of a toggle is modified in its 
                                      // onValueChanged listener, to prevent stackoverflow

    // Start is called before the first frame update
    void Start() {
        noneClimb.onValueChanged.AddListener(noneClicked);
        parkClimb.onValueChanged.AddListener(parkClicked);
        fullClimb.onValueChanged.AddListener(fullClicked);

        commentsButton.onClick.AddListener(nextScene);
        backButton.onClick.AddListener(prevScene);
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
        Variables.currentMatch.climbPos = (int)(climbLocation.value * 4);
        if(noneClimb.isOn) {
            Variables.currentMatch.climbType = 0;
        }
        if(parkClimb.isOn) {
            Variables.currentMatch.climbType = 1;
        }
        if(fullClimb.isOn) {
            Variables.currentMatch.climbType = 2;
        }
        Debug.Log(QRGenerator.getBinaryString(Variables.currentMatch));
        SceneManager.LoadScene("Comments");
    }

    void prevScene() {
        SceneManager.LoadScene("GamePieces");
    }
}
