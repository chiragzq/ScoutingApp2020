using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// The RoundData class stores all scouting data for a specific match. 
public class MatchData {
   public bool side = false; // false = left
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
   public int climbType = 0; // 0 for none, 1 for park, 2 for climb 
   public int climbPos = -1; // A number from 0 to 4 representing the location along the bar of the climb
   
   public string offenseComments = ""; 
   public string generalComments = ""; 
   public bool ctrlPanelQuick = false;
   public bool ctrlPanelFirst = false;
   public bool robustClimb = false;
   public bool effectiveDefense = false;
   public bool goodDriver = false;
   public bool stableRobot = false;

   void reset() {
      side = false;
      red = false;
      teamNumber = -1;
      matchNumber = -1;
      teamIndex = -1;

      initLine = false;
      autonLower = 0;
      autonOuter = 0;
      autonInner = 0;
   
      teleopLower = 0;
      teleopOuter = 0;
      teleopInner = 0;
   
      canSpin = false;
      rotControl = false;
      posControl = false;
   
      drops = 0;
      defenseTime = 0;
      brickTime = 0; 

      climbType = 0;
      climbPos = -1; 
      
      offenseComments = ""; 
      generalComments = ""; 

      ctrlPanelQuick = false;
      ctrlPanelFirst = false;
      robustClimb = false;
      effectiveDefense = false;
      goodDriver = false;
      stableRobot = false;
   }

   public void printMatch() {
      Debug.Log("MATCH DATA\n==========="
               + "\n" + "Side: " + (side ? "Right" : "Left")
               + "\n" + "Color: " + (red ? "Red" : "Blue")
               + "\n" + "Team " + teamNumber + ", match " + matchNumber + ", team index " + teamIndex
               + "\n" + "AUTON\n==========="
               + "\n" + "Init line: " + (initLine ? "Yes" : " No")
               + "\n" + autonLower + " Lower, " + autonOuter + " Outer, " + autonInner + " Inner"
               + "\n" + "TELEOP\n==========="
               + "\n" + teleopLower + " Lower, " + teleopOuter + " Outer, " + teleopInner + " Inner"
               + "\n" + "Can spin: " + (canSpin ? "Yes" : "No")
               + "\n" + "Rot control: " + (rotControl ? "Yes" : "No")
               + "\n" + "Pos control: " + (posControl ? "Yes" : "No")
               + "\n" + "Drops: " + drops
               + "\n" + "Defense: " + defenseTime + "s"
               + "\n" + "Bricked: " + brickTime + "s"
               + "\n" + "ENDGAME\n==========="
               + "\n" + "Climb type: " + (climbType == 2 ? "Climb" : (climbType == 1 ? "Park" : "None"))
               + "\n" + "Climb location: " + (climbType != 2 ? "N/A" : "" + climbPos)
               + "\n" + "COMMENTS\n==========="
               + "\n" + "Offense comments: " + offenseComments
               + "\n" + "General comments: " + generalComments
               + "\n" + "Control Panel Quick: " + (ctrlPanelQuick ? "Yes" : "No")
               + "\n" + "Control Panel First Try: " + (ctrlPanelFirst ? "Yes" : "No")
               + "\n" + "Robust Climb: " + (robustClimb ? "Yes" : "No")
               + "\n" + "Effective Defense: " + (effectiveDefense ? "Yes" : "No")
               + "\n" + "Good Driver: " + (goodDriver ? "Yes" : "No")
               + "\n" + "Stable Robot: " + (stableRobot ? "Yes" : "No"));
   }
}
