using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GamePiecesScouting : MonoBehaviour
{
    public SpriteRenderer powerPort;

    public Button innerPlus;
    public Button innerMinus;
    public TextMeshProUGUI innerText;

    public Button outerPlus;
    public Button outerMinus;
    public TextMeshProUGUI outerText;

    public Button lowerPlus;
    public Button lowerMinus;
    public TextMeshProUGUI lowerText;

    public Button dropsPlus;
    public Button dropsMinus;
    public TextMeshProUGUI dropsText;

    // public Toggle canSpinToggle;
    public Toggle rotControlToggle;
    public Toggle posControlToggle;
    public Toggle initLineToggle;

    private bool isAuton = true;
    public Button autonToggle;
    public TextMeshProUGUI autonButtonText;

    private int defenseTimestamp = 0;
    public Button defenseButton;
    public TextMeshProUGUI defenseButtonText;

    private int brickedTimestamp = 0;
    public Button brickedButton;
    public TextMeshProUGUI brickedButtonText;

    public Button backButton;
    public Button nextButton;

    // Start is called before the first frame update
    void Start() {
        powerPort.sprite = Resources.Load<Sprite>("Images/" + (Variables.currentMatch.red ? "Red" : "Blue") + "PowerPort");

        innerPlus.onClick.AddListener(innerPlusHandler);
        innerMinus.onClick.AddListener(innerMinusHandler);
        outerPlus.onClick.AddListener(outerPlusHandler);
        outerMinus.onClick.AddListener(outerMinusHandler);
        lowerPlus.onClick.AddListener(lowerPlusHandler);
        lowerMinus.onClick.AddListener(lowerMinusHandler);
        dropsPlus.onClick.AddListener(dropsPlusHandler);
        dropsMinus.onClick.AddListener(dropsMinusHandler);

        autonToggle.onClick.AddListener(toggleAuton);
        defenseButton.onClick.AddListener(toggleDefense);
        brickedButton.onClick.AddListener(toggleBricked);
        backButton.onClick.AddListener(backScene);
        nextButton.onClick.AddListener(nextScene);
    }

    void innerPlusHandler() {
        if(isAuton) {
            Variables.currentMatch.autonInner++;
        } else {
            Variables.currentMatch.teleopInner++;
        }
    }

    void innerMinusHandler() {
        if(isAuton && Variables.currentMatch.autonInner > 0) {
            Variables.currentMatch.autonInner--;
        } 
        if(!isAuton && Variables.currentMatch.teleopInner > 0) {
            Variables.currentMatch.teleopInner--;
        }
    }

    void outerPlusHandler() {
        if(isAuton) {
            Variables.currentMatch.autonOuter++;
        } else {
            Variables.currentMatch.teleopOuter++;
        }
    }

    void outerMinusHandler() {
        if(isAuton && Variables.currentMatch.autonOuter > 0) {
            Variables.currentMatch.autonOuter--;
        } 
        if(!isAuton && Variables.currentMatch.teleopOuter > 0) {
            Variables.currentMatch.teleopOuter--;
        }
    }

    void lowerPlusHandler() {
        if(isAuton) {
            Variables.currentMatch.autonLower++;
        } else {
            Variables.currentMatch.teleopLower++;
        }
    }

    void lowerMinusHandler() {
        if(isAuton && Variables.currentMatch.autonLower > 0) {
            Variables.currentMatch.autonLower--;
        } 
        if(!isAuton && Variables.currentMatch.teleopLower > 0) {
            Variables.currentMatch.teleopLower--;
        }
    }

    void dropsPlusHandler() {
        Variables.currentMatch.drops++;
    }

    void dropsMinusHandler() {
        if(Variables.currentMatch.drops > 0) {
            Variables.currentMatch.drops--;
        }
    }

    void toggleAuton() {
        isAuton = isAuton == false;
        if(autonButtonText.text == "Auton") {
            autonButtonText.text = "Teleop";
            autonToggle.GetComponent<Image>().color = new Color(103f/255, 15f/255, 219f/255);
        } else {
            autonButtonText.text = "Auton";
            autonToggle.GetComponent<Image>().color = new Color(231f/255, 151f/255, 1f/255);
        }
    }

    void toggleDefense() {
        if(defenseTimestamp == 0) {
            defenseTimestamp = currentTime();
            defenseButton.GetComponent<Image>().color = new Color(190f/255, 190f/255, 190f/255);
        } else {
            Variables.currentMatch.defenseTime += currentTime() - defenseTimestamp;
            defenseTimestamp = 0;
            defenseButton.GetComponent<Image>().color = new Color(255f/255, 255f/255, 255f/255);
        }
    }

    void toggleBricked() {
        if(brickedTimestamp == 0) {
            brickedTimestamp = currentTime();
            brickedButton.GetComponent<Image>().color = new Color(190f/255, 190f/255, 190f/255);
        } else {
            Variables.currentMatch.brickTime += currentTime() - brickedTimestamp;
            brickedTimestamp = 0;
            brickedButton.GetComponent<Image>().color = new Color(255f/255, 255f/255, 255f/255);
        }
    }

    void backScene() {
        SceneManager.LoadScene("MainMenu");
    }
    
    void nextScene() {
        Variables.currentMatch.initLine = initLineToggle.isOn;
        // Variables.currentMatch.canSpin = canSpinToggle.isOn;
        Variables.currentMatch.rotControl = rotControlToggle.isOn;
        Variables.currentMatch.posControl = posControlToggle.isOn;

        if(defenseTimestamp != 0) {
            Variables.currentMatch.defenseTime += currentTime() - defenseTimestamp;
        }

        SceneManager.LoadScene("EndGame");
    }

    // Update is called once per frame
    void Update() {
        int extraTime = defenseTimestamp == 0 ? 0 : currentTime() - defenseTimestamp;
        defenseButtonText.text = convertTime(Variables.currentMatch.defenseTime + extraTime);

        extraTime = brickedTimestamp == 0 ? 0 : currentTime() - brickedTimestamp;
        brickedButtonText.text = convertTime(Variables.currentMatch.brickTime + extraTime);

        innerText.text = Variables.currentMatch.autonInner + Variables.currentMatch.teleopInner + "";
        outerText.text = Variables.currentMatch.autonOuter + Variables.currentMatch.teleopOuter + "";
        lowerText.text = Variables.currentMatch.autonLower + Variables.currentMatch.teleopLower + "";
        dropsText.text = Variables.currentMatch.drops + "";
    }

    static int currentTime() {
        return (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
    }

    string convertTime(int delta) {
        int minutes = (delta % 60);
        return ((delta / 60) % 60) + ":" + (minutes < 10 ? "0" + minutes : "" + minutes);
    }
}
