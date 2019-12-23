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

    // Start is called before the first frame update
    void Start()
    {
        if(Constants.loggedIn) {
            SceneManager.LoadScene("RoleSelection");
        }
        submitButton.onClick.AddListener(submitUsername);
    }

    void submitUsername() {
        string username = inputField.text;
        if(Array.IndexOf(Constants.usernames, username) > -1) {
            Constants.setUsername(username);
            SceneManager.LoadScene("RoleSelection");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
