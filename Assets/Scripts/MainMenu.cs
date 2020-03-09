using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using TMPro;
using UnityEditor;

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

        populateMatches();
        if(!Variables.fetchedMatches) {
            Variables.fetchedMatches = true;
            StartCoroutine(refreshMatches());
        }
    }

    IEnumerator refreshMatches() {
        using (UnityWebRequest request = UnityWebRequest.Get("http://chiragzq.github.io/schedule/"))
        // using (UnityWebRequest request = UnityWebRequest.Get("http://localhost"))
        {
            yield return request.Send();

            if (request.isNetworkError) // Error
            {
                Debug.Log(request.error);
            }
            else // Success
            {
                string[] teams = request.downloadHandler.text.Split(' ');
                PlayerPrefsArray.SetIntArray("matches", Array.ConvertAll(teams, int.Parse));
                populateMatches();  
            }
        }
    }

    void populateMatches() {
        int[] teams = PlayerPrefsArray.GetIntArray("matches", 0, 0);
        Constants.matchTeams = new int[teams.Length / 6][];
        for(int i = 0;i < teams.Length;i ++) {
            int teamNumber = teams[i];
            if(i % 6 == 0)
                Constants.matchTeams[i / 6] = new int[6];
            Constants.matchTeams[i / 6][i % 6] = teamNumber;
        }
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
