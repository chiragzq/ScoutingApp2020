using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Login : MonoBehaviour
{
    public Button submitButton;
    public TMP_InputField inputField;

    void Awake() {
        if(Constants.loggedIn) {
            if(Constants.roleIndex == -1)
                SceneManager.LoadScene("RoleSelection");
            else
                SceneManager.LoadScene("MainMenu");
        }
        submitButton.onClick.AddListener(SubmitUsername);
    }

    void SubmitUsername() {
        string username = inputField.text;
        if(Array.IndexOf(Constants.usernames, username) > -1) {
            Constants.setUsername(username);
            if(Constants.roleIndex == -1)
                SceneManager.LoadScene("RoleSelection");
            else
                SceneManager.LoadScene("MainMenu");
        }
    }

    // Update is called once per frame
    void Update() {
        
    }
}
