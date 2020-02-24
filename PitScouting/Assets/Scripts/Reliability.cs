using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Reliability : MonoBehaviour
{
    //dropdown menus to get info about stability and robustness  of robot
    public TMPro.TMP_Dropdown stabilityDropdown;
    public TMPro.TMP_Dropdown robustnessDropdown;

    //buttons to exit scene
    public Button reliabilityBackButton;
    public Button reliabilityNextButton;

    // Start is called before the first frame update
    void Start()
    {
        //adds listeners to the dropdowns to get info about stability and robustness
        stabilityDropdown.onValueChanged.AddListener(delegate {StabilityValueChanged();});  
        robustnessDropdown.onValueChanged.AddListener(delegate{RobustnessValueChanged();});

        //adds a listener to the button to go to previous scene
        reliabilityBackButton.onClick.AddListener(delegate {LoadStrategyScene();});
    }

    //change the values for stability and robustness
    public void StabilityValueChanged() {
        if (stabilityDropdown.value == 1) {
            Data.teamData.roboStability = "very likely to tip or fall";
        }
        if (stabilityDropdown.value == 2) {
            Data.teamData.roboStability = "sometimes tips or falls";
        }
        if (stabilityDropdown.value == 3) {
            Data.teamData.roboStability = "almost/never tips or falls";
        }
        CheckIfCompleted();
    }
    public void RobustnessValueChanged() {
        if (robustnessDropdown.value == 1) {
            Data.teamData.roboRobustness = "very likely to break or brick";
        }
        if (robustnessDropdown.value == 2) {
            Data.teamData.roboRobustness = "sometimes breaks or bricks";
        }
        if (robustnessDropdown.value == 3) {
            Data.teamData.roboRobustness = "almost/never breaks or bricks";
        }
        CheckIfCompleted();
    }

    //checks if all data has been entered correctly, then adds listener to button to go to next scene
    public void CheckIfCompleted() {
        if (stabilityDropdown.value != 0) {
            if (robustnessDropdown.value != 0) {
                reliabilityNextButton.onClick.AddListener(delegate {LoadCommentsScene();});
            }
        }
    }

    //load different scenes
    public void LoadStrategyScene() {
        SceneManager.LoadScene("Strategy");
    }
    public void LoadCommentsScene() {
        SceneManager.LoadScene("Comments");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
