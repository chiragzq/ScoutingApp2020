using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class RoleSelection : MonoBehaviour
{
    public Button button;
    public TMP_Dropdown dropdown;

    // Start is called before the first frame update
    void Start() {
        button.onClick.AddListener(SetRole);
    }

    void SetRole() {
        Constants.setRole(dropdown.value);
        SceneManager.LoadScene("MainMenu");

        // leftFlip.onClick.AddListener(() => {
        //         Constants.setFlipped(!Constants.flipLocation);
        //          if(Constants.flipLocation) 
        //             xRot = 180;
        //         else
        //             xRot = 0;
        //         field.transform.localRotation = Quaternion.Euler(xRot, yRot, 0);
        //     });
    }
}
