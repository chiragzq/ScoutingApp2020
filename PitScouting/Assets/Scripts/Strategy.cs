using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Strategy : MonoBehaviour
{
    //dropdown menus and input field to get info about team strategy
    public TMPro.TMP_Dropdown autonStartDropdown;
    public TMPro.TMP_Dropdown autonScoringDropdown;
    public TMPro.TMP_Dropdown defenseDropdown;
    public TMPro.TMP_InputField pathsInputField;

    //buttons to exit scene
    public Button strategyBackButton;
    public Button strategyNextButton;

    // Start is called before the first frame update
    void Start()
    {
        //adds listeners to the dropdowns and  input  field to get info for
        //the amount of balls the robot starts auton with
        autonStartDropdown.onValueChanged.AddListener(delegate {AutonStartChanged();});
        //the amount of balls the robot will score during auton
        autonScoringDropdown.onValueChanged.AddListener(delegate {AutonScoringChanged();});
        //the team's defense strategy/capabilities
        defenseDropdown.onValueChanged.AddListener(delegate {DefenseStratChanged();});
        //the team's path strat
        pathsInputField.onEndEdit.AddListener(delegate {PathStratChanged();});

        //adds a listener to the button to go to previous scene
        strategyBackButton.onClick.AddListener(delegate {LoadScoringScene();});
    }

    //change the info for auton start, scoring, defense, and  paths
    public void AutonStartChanged() {
        Data.teamData.autonStartWithBalls = autonStartDropdown.value;
        CheckIfCompleted();
    }
    public void AutonScoringChanged() {
        Data.teamData.autonScoreBalls = autonScoringDropdown.value;
        CheckIfCompleted();
    }
    public void DefenseStratChanged() {
        if (defenseDropdown.value == 1) {
            Data.teamData.defenseStrat = "can't play defense";
        }
        if (defenseDropdown.value == 2) {
            Data.teamData.defenseStrat = "can play defense if necessary";
        }
        if (defenseDropdown.value == 3) {
            Data.teamData.defenseStrat = "only plays defense";
        }
        CheckIfCompleted();
    }
    public void PathStratChanged() {
        Data.teamData.pathStrat = pathsInputField.text;
        CheckIfCompleted();
    }

    //checks if all data has been entered correctly, then adds listener to button to go to next scene
    public void CheckIfCompleted() {
        if (autonStartDropdown.value != 0) {
            if (autonScoringDropdown.value != 0) {
                if (defenseDropdown.value != 0) {
                    if (!string.IsNullOrEmpty(pathsInputField.text)) {
                        strategyNextButton.onClick.AddListener(delegate {LoadReliabilityScene();});
                    }
                }
            }
        }
    }

    //load different scenes
    public void LoadScoringScene() {
        SceneManager.LoadScene("Scoring");
    }
    public void LoadReliabilityScene() {
        SceneManager.LoadScene("Reliability");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
