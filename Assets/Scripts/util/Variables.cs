using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Variables stores temporary values that are used between scenes.
public class Variables : MonoBehaviour
{   
    // The current match data (or null if no match is being scouted)
    public static MatchData currentMatch = new MatchData();

    // The current location data
    public static LocationData currentLocation = new LocationData();

    public static bool fetchedMatches = false;
}
