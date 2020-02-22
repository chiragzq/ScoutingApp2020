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

        //adds a listener to the button to exit the scene
        teamNextButton.onClick.AddListener(delegate {LoadRobotScene();});
    }

    //changes the team number
    public void TeamNumberChanged() {
        Data.teamData.teamNumber = int.Parse(teamNumberInputField.text);
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
