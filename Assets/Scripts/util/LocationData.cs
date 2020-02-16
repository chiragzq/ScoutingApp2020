using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationData {
    public bool side = false; // false = left
    public bool red = true; // side ^ red = y 180
    public bool verticalFlip = false; // x 180     
    public int matchNumber = -1;
    public int teamNumber = -1;
    public int teamIndex = -1; // Index of the team in the match data Constant object.

    public int defenseTime = 0;
    public bool initLine = false;
    public bool canSpin = false;
    public bool rotControl = false;
    public bool posControl = false;
    public bool bricked = false; // in seconds

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

    public Cycle currentCycle = new Cycle();

    public List<Cycle> autonCycles = new List<Cycle>();
    public List<Cycle> teleopCycles = new List<Cycle>();

    public class Cycle {
        public int x; // 16
        public int y; // 9
        public int timestamp;
        public int drops;
        public int lower;
        public int outer;
        public int inner;

        public Cycle() {  }

        public Cycle(int x, int y, int timestamp, int miss, int lower, int outer, int inner) {
            this.x = x;
            this.y = y;
            this.timestamp = timestamp;
            this.drops = miss;
            this.lower = lower;
            this.outer = outer;
            this.inner = inner;
        }  
    }
}