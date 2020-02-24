using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Team : MonoBehaviour
{
    //input field to read team number
    public TMPro.TMP_InputField teamNumberInputField;

    //button to exit scene
    public Button teamNextButton;

    // Start is called before the first frame update
    void Start()
    {
        //adds a listener to the input field to read team number
        teamNumberInputField.onEndEdit.AddListener(delegate {TeamNumberChanged();});
    }

    //changes the team number
    public void TeamNumberChanged() {
        int teamNumberInput;
        if (int.TryParse(teamNumberInputField.text, out teamNumberInput))
        {
            Data.teamData.teamNumber = teamNumberInput;
            teamNextButton.onClick.AddListener(delegate {LoadRobotScene();});  //adds a listener to the button to exit the scene
        }
    }

    //loads a different scene
    public void LoadRobotScene() {
        SceneManager.LoadScene("Robot");
    }

    
    // Update is called once per frame
    void Update()
    {
        
    }
}
