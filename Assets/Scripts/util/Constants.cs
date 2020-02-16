using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Constants stores data that is persistent between uses of the app.
// This does not necessarily that their values may be changed.
// It also contains some utility methods for getting values (e.g. Role Names)
// 
// Pre competition checklist:
// Update usernames
// Update versionstring
// Update matchtemas
public class Constants : MonoBehaviour
{
    public const string versionString = "Version 0.2.1 (Development)";

    // List of usernames who use the app
    public static readonly string[] usernames = {
        "22chiragk",
        "22gloriaz",
        "guest"
    };

    // Array of matches and the teams that are in them, used for QR generation.
    public static readonly int[][] matchTeams = { new int[]{ 6305,7057,7663,3495,1351,1671 }, new int[]{ 5461,1323,1671,6926,3495,1422 }, new int[]{ 2489,5817,7663,6506,3257,1388 }, new int[]{ 5026,3970,3189,5458,585,1967 }, new int[]{ 6657,2085,2813,4135,2135,1351 }, new int[]{ 5104,1678,3303,5274,766,6981 }, new int[]{ 1662,701,6711,2854,751,5728 }, new int[]{ 7413,6241,5852,4698,5134,6305 }, new int[]{ 1967,3669,1323,585,7057,7589 }, new int[]{ 6981,1072,5104,6657,1351,2489 }, new int[]{ 5728,5458,5026,751,7663,5274 }, new int[]{ 5134,1323,6711,5274,6657,1280 }, new int[]{ 3970,6804,2135,5852,4135,701 }, new int[]{ 6711,6305,3669,766,4698,1388 }, new int[]{ 6506,7413,6926,7057,1662,2085 }, new int[]{ 3189,1678,5817,2813,1671,5134 }, new int[]{ 1422,2854,3257,3303,6884,3495 }, new int[]{ 1280,585,6711,6241,1072,5461 }, new int[]{ 3970,6926,751,5274,7589,6506 }, new int[]{ 2135,4698,3189,7663,1662,1323 }, new int[]{ 1678,1967,3257,2085,6305,5104 }, new int[]{ 701,3303,2854,1351,1280,5817 }, new int[]{ 2489,6804,4698,6926,6884,5817 }, new int[]{ 6884,5134,766,6241,3495,2813 }, new int[]{ 6981,1388,6804,7413,5728,7057 }, new int[]{ 2489,5852,5458,3669,1671,4135 }, new int[]{ 6657,5026,1678,1422,5461,1662 }, new int[]{ 1351,3257,7589,6241,5274,3189 }, new int[]{ 5134,6926,5728,2135,6305,3303 }, new int[]{ 7057,2813,6506,4698,1280,5458 }, new int[]{ 751,5852,5461,2085,766,2489 }, new int[]{ 6804,5817,1072,5104,6711,1422 }, new int[]{ 7663,1388,1671,6657,1967,701 }, new int[]{ 5104,4135,5461,3189,7589,3303 }, new int[]{ 4135,3495,2854,7413,6981,585 }, new int[]{ 1323,5026,6926,6884,3669,3970 }, new int[]{ 3257,7057,5274,5461,2813,6804 }, new int[]{ 1662,3303,1280,1967,7663,5852 }, new int[]{ 1072,1678,1351,5728,4698,4135 }, new int[]{ 766,3189,6657,6506,2489,3970 }, new int[]{ 1671,2135,7589,6711,7413,5026 }, new int[]{ 5458,701,6305,1323,6981,2854 }, new int[]{ 1388,1422,6884,585,5134,751 }, new int[]{ 2085,6241,3669,5104,5817,3495 }, new int[]{ 1072,3669,7413,701,751,6506 }, new int[]{ 2813,3970,7413,6711,3303,6926 }, new int[]{ 1671,5274,2489,1280,2135,2854 }, new int[]{ 7589,766,6804,7663,1351,585 }, new int[]{ 3257,3495,5461,1072,5728,1662 }, new int[]{ 5026,1388,6241,1323,6506,1678 }, new int[]{ 2085,4698,6981,1422,3189,5134 }, new int[]{ 6657,5852,5104,701,6884,7057 }, new int[]{ 5458,751,4135,5817,6305,1967 }, new int[]{ 7663,1280,2813,3669,1388,5728 }, new int[]{ 1323,1422,1351,3257,7413,2489 }, new int[]{ 1388,1662,2135,766,5458,1422 }, new int[]{ 3495,3189,6506,6804,6711,5852 }, new int[]{ 7589,5458,2085,3303,6657,1072 }, new int[]{ 2854,5104,766,5026,1967,4698 }, new int[]{ 585,6241,1678,6926,701,2135 }, new int[]{ 6884,4135,6305,1662,5274,3669 }, new int[]{ 1671,5817,751,3970,5461,6981 }, new int[]{ 3303,5026,5134,7057,2489,1072 }, new int[]{ 2135,6657,5458,6926,5104,3257 }, new int[]{ 4698,5274,701,3495,2085,585 }, new int[]{ 6711,6884,7663,4135,6981,1678 }, new int[]{ 2854,3970,585,5728,3257,2085 }, new int[]{ 5817,5728,766,3189,7413,1323 }, new int[]{ 1280,1422,7057,6305,7589,3970 }, new int[]{ 751,2813,1662,6804,1671,6241 }, new int[]{ 5134,6506,3669,1351,5461,1967 }, new int[]{ 5852,6926,3189,1388,2854,1072 }, new int[]{ 3257,701,1280,766,4135,5026 }, new int[]{ 3303,585,4698,6305,751,6657 }, new int[]{ 1967,7057,3495,1678,2489,2135 }, new int[]{ 5461,7663,7413,3970,5104,6241 }, new int[]{ 6981,1662,7589,2813,1323,1388 }, new int[]{ 1967,6981,6241,5852,5026,2813 }, new int[]{ 5728,1422,5274,5817,6506,5852 }, new int[]{ 1351,2085,6884,1671,6711,5458 }, new int[]{ 3669,6804,5104,5134,2854,6657 }, new int[]{ 7589,1072,1280,1678,6804,6884 }, };
    public static readonly string[] roles = {
        "Game Pieces",
        "Location"
    };

    public static int roleIndex = PlayerPrefs.GetInt("role", -1);

    public static bool loggedIn = PlayerPrefs.HasKey("username");
    public static string username = PlayerPrefs.GetString("username", null);

    public static bool flipLocation = PlayerPrefs.GetInt("flip", 0) == 1;

    void Start() {
        // PlayerPrefs.DeleteAll();
    }

    public static void setUsername(string newUsername) {
        username = newUsername;
        PlayerPrefs.SetString("username", newUsername);
        loggedIn = true;
    }

    public static string getFirstname() {
        if(username == "guest") 
            return "Guest";
        else
            return username.Substring(2, Constants.username.Length - 3);
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

    public static void setFlipped(bool newFlip) {
        PlayerPrefs.SetInt("flip", newFlip ? 1 : 0);
        flipLocation = newFlip;
    }
}
