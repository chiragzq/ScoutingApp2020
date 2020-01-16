using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Comments : MonoBehaviour
{
    public TextMeshProUGUI offenseText;
    public TextMeshProUGUI generalText;

    public Toggle ctrlPanelQuick;
    public Toggle ctrlPanelFirst;
    public Toggle robustClimb;
    public Toggle effectiveDefense;
    public Toggle goodDriver;
    public Toggle stableRobot;

    public Button nextButton;

    // Start is called before the first frame update
    void Start() { 
       nextButton.onClick.AddListener(nextScene);
    }

    // Update is called once per frame
    void Update() {
        
    }

    void nextScene() {
        Variables.currentMatch.ctrlPanelQuick = ctrlPanelQuick.isOn;
        Variables.currentMatch.ctrlPanelFirst = ctrlPanelFirst.isOn;
        Variables.currentMatch.robustClimb = robustClimb.isOn;
        Variables.currentMatch.effectiveDefense = effectiveDefense.isOn;
        Variables.currentMatch.goodDriver = goodDriver.isOn;
        Variables.currentMatch.stableRobot = stableRobot.isOn;

        Variables.currentMatch.offenseComments = offenseText.text;
        Variables.currentMatch.generalComments = generalText.text;
        SceneManager.LoadScene("QR");
    }
}
