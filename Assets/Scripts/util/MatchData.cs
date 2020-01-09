using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// The RoundData class stores all scouting data for a specific match. 
public class MatchData : MonoBehaviour {
   public bool red = false;         
   public int matchNumber = -1;
   public int teamNumber = -1;
   public int teamIndex = -1; // Index of the team in the match data Constant object.

   // Auton data
   public bool initLine = false;
   public int autonLower = 0;
   public int autonOuter = 0;
   public int autonInner = 0;

   // Teleop data
   public int teleopLower = 0;
   public int teleopOuter = 0;
   public int teleopInner = 0;

   public bool canSpin = false;
   public bool rotControl = false;
   public bool posControl = false;

   public int drops = 0;
   public int defenseTime = 0; // in seconds
   public int brickTime = 0; // in seconds

   // Endgame data
   public bool canClimb = false;
   public int climbPos = -1; // A number from 1 to 7 representing the location along the bar of the climb
   
   public string comments = ""; // vary depending on role

   public string ToString() {
      return "MATCH DATA\n===========";
   }
}
