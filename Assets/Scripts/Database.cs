using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
The Database object is in charge of keeping track of all
data taken down during a match of scouting. It also handles
operations related to the logged-in user's username (which is 
the only data that needs to be persisted between sessions).
*/
public class Database : MonoBehaviour {

   public bool loggedIn;

   public bool red = false;
   public int teamNumber = -1;
   public int matchNumber = -1;
   public string scoutingRole = "norole";

   public int timeSpentOnDefense = 0; // in seconds

   // specific variables for scoring/endgame stats
   
   public string comments = "nocomments"; // vary depending on role

   public bool noShow = false;

   void Start() {
     loggedIn = PlayerPrefs.HasKey("username");
     
     DontDestroyOnLoad(transform.gameObject); // persisting
   }

   public void setUsername(string username) {
      PlayerPrefs.SetString("username", username);
   }

   public string getUsername() {
      if (!isLoggedIn()) return "";
      return PlayerPrefs.GetString("username");
   }

   public bool isLoggedIn() {
      return PlayerPrefs.HasKey("username");
   }

   public void logout() {
      PlayerPrefs.DeleteKey("username");
      this.wipe();
   }

   public void wipe() {
      red = false;
      teamNumber = -1;
      matchNumber = -1;
      scoutingRole = "norole";
      timeSpentOnDefense = 0;
      // wipe specific variables
      comments = "nocomments";
      noShow = false;
   }

}
