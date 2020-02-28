﻿using System;
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
    public TextMeshProUGUI boltmanText;

    public TMP_InputField matchNumberInput;
    public TMP_Dropdown teamDropdown;

    public Button leftStartButton;
    public Button rightStartButton;
    public Button rolesButton;
    public Button logoutButton;

    // Start is called before the first frame update
    void Start() {
        leftStartButton.onClick.AddListener(LeftStartRound);
        rightStartButton.onClick.AddListener(RightStartRound);
        rolesButton.onClick.AddListener(ChangeRoles);
        logoutButton.onClick.AddListener(LogOut);

        matchNumberInput.onValueChanged.AddListener(checkMatchNumberInput);

        versionText.text = Constants.versionString;
        
        string firstName = Constants.getFirstname();
        firstName = char.ToUpper(firstName[0]) + firstName.Substring(1);
        userText.text = "Welcome " + firstName + ", your role is " + Constants.getRoleName() + ".";

        string boltmanQuote = Constants.getBoltmanQuote();
        boltmanText.text = "\"" + boltmanQuote + "\" --Boltman";

        Application.targetFrameRate = 15;
        QualitySettings.vSyncCount = 0;
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
            leftStartButton.interactable = true;
            rightStartButton.interactable = true;

            if(Constants.roleIndex == 0) {
                Variables.currentMatch = new MatchData();
                Variables.currentMatch.matchNumber = matchNumber + 1;
            } else {
                Variables.currentLocation = new LocationData();
                Variables.currentLocation.matchNumber = matchNumber + 1;
            }
        } else {
            teamDropdown.ClearOptions();
            teamDropdown.interactable = false;
            
            leftStartButton.interactable = false;
            rightStartButton.interactable = false;
        }
    }

    void LeftStartRound() {
        if(Constants.roleIndex == 0) {
            Variables.currentMatch.side = false;
            Variables.currentMatch.teamIndex = teamDropdown.value;
            Variables.currentMatch.teamNumber = Int32.Parse(teamDropdown.options[teamDropdown.value].text);
            Variables.currentMatch.red =  teamDropdown.value >= 3;
            SceneManager.LoadScene("GamePieces");
        } else if(Constants.roleIndex == 1) {
            Variables.currentLocation.side = false;
            Variables.currentLocation.teamIndex = teamDropdown.value;
            Variables.currentLocation.teamNumber = Int32.Parse(teamDropdown.options[teamDropdown.value].text);
            Variables.currentLocation.red =  teamDropdown.value >= 3;
            SceneManager.LoadScene("Location");
        }
    }

    void RightStartRound() {
        if(Constants.roleIndex == 0) {
            Variables.currentMatch.side = true;
            Variables.currentMatch.teamIndex = teamDropdown.value;
            Variables.currentMatch.teamNumber = Int32.Parse(teamDropdown.options[teamDropdown.value].text);
            Variables.currentMatch.red =  teamDropdown.value >= 3;
            SceneManager.LoadScene("GamePieces");
        } else if(Constants.roleIndex == 1) {
            Variables.currentLocation.side = true;
            Variables.currentLocation.teamIndex = teamDropdown.value;
            Variables.currentLocation.teamNumber = Int32.Parse(teamDropdown.options[teamDropdown.value].text);
            Variables.currentLocation.red =  teamDropdown.value >= 3;
            SceneManager.LoadScene("Location");
        }
    }

    void LogOut() {
        Constants.loggedIn = false;
        SceneManager.LoadScene("Login");
    }

    void ChangeRoles() {
        SceneManager.LoadScene("RoleSelection");
    }


    // Update is called once per frame
    void Update() {
        
    }
}
