using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public TextMeshProUGUI versionText;
    public TextMeshProUGUI userText;

    public TMP_InputField matchNumberInput;
    public TMP_Dropdown teamDropdown;

    public Button startButton;
    public Button recordsButton;
    public Button rolesButton;

    // Start is called before the first frame update
    void Start() {
        startButton.onClick.AddListener(StartRound);
        recordsButton.onClick.AddListener(OpenRecords);
        rolesButton.onClick.AddListener(ChangeRoles);

        matchNumberInput.onValueChanged.AddListener(checkMatchNumberInput);

        versionText.text = Constants.versionString;
        
        string firstName = Constants.username.Substring(2, Constants.username.Length - 3);
        firstName = char.ToUpper(firstName[0]) + firstName.Substring(1);
        userText.text = "Welcome " + firstName + ", your role is " + Constants.getRoleName() + ".";
    }

    void checkMatchNumberInput(string value) {
        if(value == "" || value.Length > 5) {
            value = "0"; // So that it still goes through the dropdown disbaling logic
        }
        int matchNumber = Int32.Parse(value);
        if(0 < matchNumber && matchNumber <= Constants.matchTeams.Length) {            
            matchNumber--; // 0-index it
            List<string> teamOptions = new List<string>();
            foreach(int teamNumber in Constants.matchTeams[matchNumber]) {
                teamOptions.Add(teamNumber.ToString());
            }
            
            teamDropdown.ClearOptions();
            teamDropdown.AddOptions(teamOptions);
            teamDropdown.interactable = true;
            startButton.interactable = true;

            Variables.currentMatch = new MatchData();
            Variables.currentMatch.matchNumber = matchNumber;
        } else {
            teamDropdown.ClearOptions();
            teamDropdown.interactable = false;
            startButton.interactable = false;
        }
    }

    void StartRound() {
        Variables.currentMatch.teamIndex = teamDropdown.value;
        Variables.currentMatch.teamNumber = Int32.Parse(teamDropdown.options[teamDropdown.value].text);
        Variables.currentMatch.red =  teamDropdown.value < 3;
        // SceneManager.LoadScene("GamePieces")
    }

    void OpenRecords() {
        // TODO
    }

    void ChangeRoles() {
        SceneManager.LoadScene("RoleSelection");
    }


    // Update is called once per frame
    void Update() {
        
    }
}
