using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Comments : MonoBehaviour
{
    //input fields to get scouter comments on  robot
    public TMPro.TMP_InputField strengthsInputField;
    public TMPro.TMP_InputField weaknessesInputField;
    public TMPro.TMP_InputField generalCommentsInputField;

    //buttons to exit scene
    public Button CommentsBackButton;
    public Button CommentsNextButton;

    // Start is called before the first frame update
    void Start()
    {
        //adds listeners to the input fields to get comments about strengths, weaknesses, and general observations
        strengthsInputField.onEndEdit.AddListener(delegate {StrengthsCommentsChanged();});
        weaknessesInputField.onEndEdit.AddListener(delegate {WeaknessesCommentsChanged();});
        generalCommentsInputField.onValueChanged.AddListener(delegate {GeneralCommentsChanged();});

        //adds listeners to the buttons to exit the scene
        CommentsBackButton.onClick.AddListener(delegate {LoadReliabilityScene();});
        CommentsNextButton.onClick.AddListener(delegate {LoadEndScene();});
    }

    //changes values of the strings containing scouter comments
    public void StrengthsCommentsChanged() {
        Data.teamData.strengthsComments = strengthsInputField.text;
    }
    public void WeaknessesCommentsChanged() {
        Data.teamData.weaknessesComments = weaknessesInputField.text;
    }
    public void GeneralCommentsChanged() {
        Data.teamData.generalComments = generalCommentsInputField.text;
    }

    //load different scenes
    public void LoadReliabilityScene() {
        SceneManager.LoadScene("Reliability");
    }
    public void LoadEndScene() {
        SceneManager.LoadScene("End");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
