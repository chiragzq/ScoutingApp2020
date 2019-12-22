using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Landing : MonoBehaviour
{

   private Database db;
   private Validator validator;

   public TMPro.TMP_InputField usernameInput;
   public Button submitButton;
   public TMPro.TMP_Text tooltip;

    void Awake()
    {
       db = GameObject.Find("Base").GetComponent<Database>();
       validator = GameObject.Find("Base").GetComponent<Validator>();

       if (db.isLoggedIn()) {
         SceneManager.LoadScene("RoleSelection");
       } else {
          submitButton.onClick.AddListener(submit);
       }

      
    }

   public void submit() {
       if (validator.validateUsername(usernameInput.text)) {

          Debug.Log(usernameInput.text);

          submitButton.interactable = false; // disable the button just in case
          PlayerPrefs.SetString("username", usernameInput.text);

          SceneManager.LoadScene("RoleSelection");

       } else {
          setTooltip("* Invalid username.");
       }
    }

    void setTooltip(string message) {
       tooltip.text = message;
    }

}
