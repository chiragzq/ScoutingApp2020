using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Scoring : MonoBehaviour
{
    //dropdown menus to get robot info
    public TMPro.TMP_Dropdown goalsDropdown;
    public TMPro.TMP_Dropdown climbDropdown;
    public TMPro.TMP_Dropdown wheelSpinDropdown;

    //buttons to exit scene
    public Button scoringBackButton;
    public Button scoringNextButton;

    // Start is called before the first frame update
    void Start()
    {
        //adds listeners to the dropdowns to get values for goal scoring, endgame climb, and color wheel spin capabilities
        goalsDropdown.onValueChanged.AddListener(delegate {GoalsChanged();});    
        climbDropdown.onValueChanged.AddListener(delegate {ClimbChanged();});  
        wheelSpinDropdown.onValueChanged.AddListener(delegate {WheelControlChanged();});  

        //adds a listener to the button to go to previous scene
        scoringBackButton.onClick.AddListener(delegate {LoadRobotScene();});
    }

    //change the values of goal scoring, endgame climb, and color wheel spin capabilities
    public void GoalsChanged() {
        if (goalsDropdown.value == 1) {
            Data.teamData.canScoreGoals = "only lower";
        }
        if (goalsDropdown.value == 2) {
            Data.teamData.canScoreGoals = "lower and outer";
        }
        if (goalsDropdown.value == 3) {
            Data.teamData.canScoreGoals = "outer and inner";
        }
        if (goalsDropdown.value == 4) {
            Data.teamData.canScoreGoals = "all three";
        }
        CheckIfCompleted();
    }

    public void ClimbChanged() {
        if (climbDropdown.value == 1) {
            Data.teamData.canClimb = "no climb";
        }
        if (climbDropdown.value == 2) {
            Data.teamData.canClimb = "climb only with assist";
        }
        if (climbDropdown.value == 3) {
            Data.teamData.canClimb = "can climb";
        }
        if (climbDropdown.value == 4) {
            Data.teamData.canClimb = "can climb and assist others";
        }
        CheckIfCompleted();
    }
    public void WheelControlChanged() {
        if (wheelSpinDropdown.value == 1) {
            Data.teamData.canWheelSpin = "can't  spin";
        }
        if (wheelSpinDropdown.value == 2) {
            Data.teamData.canWheelSpin = "can spin with color control";
        }
        if (wheelSpinDropdown.value == 3) {
            Data.teamData.canWheelSpin = "can spin with count control";
        }
        if (wheelSpinDropdown.value == 4) {
            Data.teamData.canWheelSpin = "can spin with color and count control";
        }
        CheckIfCompleted();
    }

    //checks if all data has been entered correctly, then adds listener to button to go to next scene
    public void CheckIfCompleted() {
        if (goalsDropdown.value != 0) {
            if (climbDropdown.value != 0) {
                if  (wheelSpinDropdown.value != 0) {
                    scoringNextButton.onClick.AddListener(delegate {LoadStrategyScene();});
                }
            }
        }
    }

    //load different scenes
    public void LoadRobotScene() {
        SceneManager.LoadScene("Robot");
    }
    public void LoadStrategyScene() {
        SceneManager.LoadScene("Strategy");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
