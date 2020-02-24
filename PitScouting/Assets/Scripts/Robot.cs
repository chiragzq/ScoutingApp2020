using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Robot : MonoBehaviour
{
    //input fields and dropdown menus to  get robot info
    public TMPro.TMP_InputField heightInputField;
    public TMPro.TMP_InputField weightInputField;
    public TMPro.TMP_Dropdown drivetrainDropdown;

    //buttons to exit scene
    public Button robotBackButton;
    public Button robotNextButton;

    //integer input read from the input fields
    double heightInput;
    double weightInput;

    // Start is called before the first frame update
    void Start()
    {
        //adds listeners to the input fields and dropdown to get robot height, weight, drivetrain
        heightInputField.onEndEdit.AddListener(delegate {HeightChanged();});   
        weightInputField.onEndEdit.AddListener(delegate {WeightChanged();});  
        drivetrainDropdown.onValueChanged.AddListener(delegate {DrivetrainChanged();});
        
        //adds a listener to the button to go to previous scene
        robotBackButton.onClick.AddListener(delegate {LoadTeamScene();});
        
    }

    //change the values of robot height, weight, and drivetrain
    public void HeightChanged() {
        if (double.TryParse(heightInputField.text, out heightInput)) {
            Data.teamData.roboHeight = heightInput;
            CheckIfCompleted();
        }
    }
    public void WeightChanged() {
        if (double.TryParse(weightInputField.text, out weightInput)) {
            Data.teamData.roboWeight = weightInput;
            CheckIfCompleted();
        }
    }
    public void DrivetrainChanged() {
        if (drivetrainDropdown.value == 1) {
            Data.teamData.roboDrivetrain = "West Coast Drive";
        }
        if (drivetrainDropdown.value == 2) {
            Data.teamData.roboDrivetrain = "Swerve Drive";
        }
        if (drivetrainDropdown.value == 3) {
            Data.teamData.roboDrivetrain = "Tank Drive";
        }
        CheckIfCompleted();
    }

    //checks if all data has been entered correctly, then adds listener to button to go to next scene
    public void CheckIfCompleted() {
        if (heightInput != 0) {
            if (weightInput != 0) {
                if (drivetrainDropdown.value != 0) {
                    robotNextButton.onClick.AddListener(delegate {LoadScoringScene();});
                }
            }
        }
    }

    //load different scenes
    public void LoadTeamScene() {
        SceneManager.LoadScene("Team");
    }
    public void LoadScoringScene() {
        SceneManager.LoadScene("Scoring");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
