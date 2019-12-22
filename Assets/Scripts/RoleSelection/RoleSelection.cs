using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RoleSelection : MonoBehaviour
{
   private Database db;
   private Validator validator;

   public Button[] selectionButtons;   // buttons for selecting the role
   public string[] selectionRoles;

   public Button backButton;
   public Button nextButton;           // button to go to next scene

   private int selectedRole = -1;

    void Start()
    {
      // if (selectionButtons.Length != selectionRoles.Length) Debug.LogError("Role selection configured wrong, please check");

      // db = GameObject.Find("Base").GetComponent<Database>();
      // validator = GameObject.Find("Base").GetComponent<Validator>();

      // for (int i = 0; i < selectionButtons.Length; i++) {
      //    selectionButtons[i].onClick.AddListener(
      //       delegate {
      //       selectButton(i);
      //    });
      // }

      // nextButton.onClick.AddListener(loadNext);
      // nextButton.interactable = false;
    }

    void selectButton(int index) {
       
       if (selectedRole==-1) {   // nothing is selected, select the index

         Debug.Log("selected role " + selectionRoles[index]);
         selectedRole = index;
         nextButton.interactable = true;

       } else if (selectedRole==index) {     // index already selected, unselect it

         Debug.Log("unselected role " + selectionRoles[selectedRole]);
         selectedRole = -1;
         nextButton.interactable = false;

       } else {   // other index already selected, unselect it and select new index

         Debug.Log("unselected role " + selectionRoles[selectedRole] + " and selected role "+selectionRoles[index]);
         selectedRole = index;
         nextButton.interactable = true;
       }
       
    }

    void loadNext() {
       db.scoutingRole = selectionRoles[selectedRole];
       SceneManager.LoadScene("MatchSelection");
    }
}
