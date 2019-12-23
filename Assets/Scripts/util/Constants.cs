using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Constants stores data that is persistent between uses of the app.
// This does not necessarily that their values may be changed.
// It also contains some utility methods for getting values (e.g. Role Names)
public class Constants : MonoBehaviour
{
    public const string version = "v0.0.1";

    // List of usernames who use the app
    public static readonly string[] usernames = {
        "22chiragk",
        "22gloriaz",
        "guest"
    };

    // Array of matches and the teams that are in them, used for QR generation.
    public static readonly int[][] matchTeams = {
        new int[] {1678, 1072, 1323, 254, 973, 971},
        new int[] {1234, 432, 2344, 4, 13, 222},
        new int[] {3212, 4324, 4432, 1, 2, 3}
    };

    public static readonly string[] roles = {
        "Game Pieces"
    };

    public static int roleIndex = PlayerPrefs.GetInt("role", -1);

    public static bool loggedIn = PlayerPrefs.HasKey("username");
    public static string username = PlayerPrefs.GetString("username", null);

    public static void setUsername(string newUsername) {
        username = newUsername;
        PlayerPrefs.SetString("username", newUsername);
        loggedIn = true;
    }

    public static void setRole(int newRoleIndex) {
        roleIndex = newRoleIndex;
        PlayerPrefs.SetInt("role", newRoleIndex);
    }
    
    public static string getRoleName() {
        if(roleIndex == -1) {
            return "No role";
        } else {
            return roles[roleIndex];
        }
    }
}
