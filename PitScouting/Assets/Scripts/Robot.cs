using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Robot : MonoBehaviour
{
    //input fields and dropdown menus to get robot info
    public TMPro.TMP_InputField heightInputField;
    public TMPro.TMP_InputField weightInputField;
    public TMPro.TMP_Dropdown drivetrainDropdown;

    //buttons to exit scene
    public Button robotBackButton;
    public Button robotNextButton;

    // Start is called before the first frame update
    void Start()
    {
        //adds listeners to the input fields and dropdown to get robot height, weight, drivetrain
        heightInputField.onEndEdit.AddListener(delegate {HeightChanged();});   
        weightInputField.onEndEdit.AddListener(delegate {WeightChanged();});  
        drivetrainDropdown.onValueChanged.AddListener(delegate {DrivetrainChanged();});
        
        //adds listeners to the buttons to exit the scene
        robotBackButton.onClick.AddListener(delegate {LoadTeamScene();});
        robotNextButton.onClick.AddListener(delegate {LoadScoringScene();});
    }

    //change the values of robot height, weight, and drivetrain
    public void HeightChanged() {
        Data.teamData.roboHeight = float.Parse(heightInputField.text);
    }
    public void WeightChanged() {
        Data.teamData.roboWeight = float.Parse(weightInputField.text);
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
        //Data.teamData.roboDrivetrain = drivetrainDropdown.text;
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
