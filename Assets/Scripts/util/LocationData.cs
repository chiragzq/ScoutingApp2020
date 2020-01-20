using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationData {
    public bool side = false; // false = left
    public bool red = false;         
    public int matchNumber = -1;
    public int teamNumber = -1;
    public int teamIndex = -1; // Index of the team in the match data Constant object.

    public List<Cycle> cycles = new List<Cycle>();

    public class Cycle {
        public int x; // 16
        public int y; // 9
        public int timestamp;
        public int miss;
        public int lower;
        public int outer;
        public int inner;

        public Cycle(int x, int y, int timestamp, int miss, int lower, int outer, int inner) {
            this.x = x;
            this.y = y;
            this.timestamp = timestamp;
            this.miss = miss;
            this.lower = lower;
            this.outer = outer;
            this.inner = inner;
        }  
    }
}