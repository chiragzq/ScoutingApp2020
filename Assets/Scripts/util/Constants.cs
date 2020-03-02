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
// Boltman
public class Constants : MonoBehaviour
{
    public const string versionString = "Version 1.2.2 (Scouter Training)";

    // List of usernames who use the app
    public static readonly string[] usernames = {
        "22gloriaz",
        "21ankitak",
        "22kateo",
        "22connorw",
        "22dennisg",
        "21chloea",
        "22shounakg",
        "22pranavg",
        "22anirudhk",
        "22ethanh",
        "22chiragk",
        "22aidanl",
        "22alexl",
        "21harib",
        "21angelac",
        "22ethanc",
        "22zachc",
        "22arjund",
        "22alicef",
        "20finnf",
        "22adheetg",
        "22prakritj",
        "21arthurj",
        "22angiej",
        "23lauriej",
        "20jatink",
        "22shahzebl",
        "23willl",
        "23garyd",
        "22anishp",
        "23adap",
        "22anishkar",
        "20sanjayr",
        "23ariyar",
        "20rohans",
        "21ethans",
        "21aydint",
        "22michaelt",
        "22pranavv",
        "21aditiv",
        "22aimeew",
        "22alinay",
        "anand",
        "kaitlin",
        "rachel",
        "guest"
    };

    public static readonly string[] importantQuotes = {
        "What is Red? How can you prove the Red you see is the Red others see? Its just labels",
        "The Brain to notes synapse is much faster than limited app tracking.",
        "Try doing that sheet over and over , not faster than paper, pen highlighters",
        "Whatever… not trying to counter that as its non- stuff",
        "The app is now on the back burner until they go though this entire season using our existing paper/excel /highlighter method.",
        "Do you watch sports by reviewing stats? That is Fantasy football…fantasy.",
        "Digital is 0 and 1, analog is infinite. Not that hard to understand…apps ARE digital. Human Brains are ANALOG",
        "Most of the “app stuff” is driven by smartphones and an electronic generation",
        "Look at Vegas , Vegas still wins despite card counters. Teams win for reasons other than fantastic scouting.",
        "Most tracking systems are digital, we choose analog…so do Musicians both are valid",
        "As for “scouting” :not found at all in last years Game and Season Manual",
        "60-100 teams to track…not that hard some are good some are not.",
        "I base most of our scouting off horse racing. Seems to work well.",
        "Seems like scouting award is fluff. Same for strategy. Cream rises to the top",
        "If students cant track 30-50 items without AI “help” there's a problem Houston. ",
        "weak waffle language",
        "One of the biggest issues with Apps…they are limited by design , the human brain is not limited by constraints.",
        "QR codes have been around for years not really that innovative in fact originally used in car manufacturing and everyone has seen them",
        "I know personally how hard it is for a team to win a Blue Banner",
        "There is not a single student that I have come across that sees the game like I do.",
        "These notes need to be passionate and not just entries, written by someone who gets the goals of scouting.",
        "Did Apollo use computers primarily? How about Jet travel? Or even discovering other continents ?",
        "Better than “fancy app” they worked so hard on you can place that in Chairmans or something"
    };

    public static readonly string[] quotes = {
        "Qualitative scouting is a completely valid way to track teams. The sample size is well within the scout teams ability to rank teams and find ways to use partners and defeat opponents.",
        "Like any sport, you waste their time and frustrate them into fouls , while ahead then if they break you and go back to scoring 1 for 1 … you win. ",
        "― Sun Tzu, The Art of War",
        "Confirmation bias , the tendency to process information by looking for, or interpreting, information that is consistent with one's existing beliefs.",
        "Scouting is about overall performance, are they a good partner ? If foe how to defeat?",
        "A “scouting form” is actually a terrible idea.",
        "We do 100% Qualitative scouting (Excel scheds, paper, pen, highlighter and shorthand notes)",
        "Correct name , never not correct",
        "the whole thinking was app or bust . Until we spoke.",
        "Yes leaving that debate to rest. I like Citrus Dad and respect his views, I have my own.",
        "Know your own limitations and find solutions. Its simple. Observe. There is not an app for that IMO as an app has you looking down.",
        "Blue alliance has plenty of data from FMS…watching closely tells you who is good. Pen , highlighter excel with watch lists.",
        "Teams will lie, best to use you own eyes and only track what you need to form an event winning alliance",
        "If the team makes eliminations/worlds before , they are very likely to win in the future. If they never make eliminations, then they are unlikely to do so in the future.",
        "So everyone is a winner won? First robotics competition",
        "I am not going to continue to express my opinions or scouting practices in this thread as they find it “off topic” as it wasn't deemed “useful for future readers” hence the OP requested “clean up”.",
        "And attacked by @ Stryker (with 18 loves) \"individual being notorious for sharing eccentric opinions without appropriate defenses for them.\"",
        "Bye this thread enjoy your own opinions then, have at it",
        "I'll take a brain over and app…especially in a limited field size and low sample size",
        "I don't think this is at all different than sports or horse racing, same principles apply",
        "What does that mean exactly, does a number tell you “pick me”? There are many ways to do scouting, that's for certain",
        "We track all sorts of weird stuff that changes year to year. Stuff we believe in.",
        "Scouts are experienced talent evaluators who travel extensively for the purposes of watching athletes play their chosen sports and determining whether their set of skills and talents represent what is needed by the scout's organization.",
        "In the end if you do scouting well , you know your team well. Then its a matter of building the strongest alliance to have a good chance against all comers",
        "Not true if you LEAVE… seriously stop trying to win this argument",
        "Have you ever gone to a horse race with a new person that picks winners by “Cutesy Name”? It happens they pick a cute name and they win",
        "I suspect most wins at regional and championship are simple pair ups…not driven by any scouting app.",
        "Observation and notes can trump fancy new “just in” technology rich scouting app",
        "Amazing the worlds best inventions were accomplished without a single computer.",
        "Not that hard to “track” 30-50 teams in most competitions.",
        "Note 3: Not following the crowd, can be beneficial (see 2009 financial “crisis”)",
        "This scouting award will certainly be dominated by a subset of more boisterous teams",
        "Back to Horseracing, if it was easy to pick a winner don't you think with all the money involved , someone would create a program to pick a winner every time? Hasn't happened.",
        "Sure 1678 has a great record and would not have been “as great” without scouting doing its job.",
        "No amount of notes will convey what a simple conversation can convey as humans take visual cues from each other.",
        "Scouting involves luck. look at handicappers or stock brokers… its all luck finding the trend at the right time. There is no magic sauce. ",
        "Golden Worm Blasters",
        "I decided to comment based on my experience with students. No harm no foul. Sorry if a resolution was reached 3 mo ago",
        "What scouting brings is Intelligence… this bodes well in team interactions and gives you the intelligence high ground in competition or picking.",
        "The class handicapper judges the merits of a horse not by the time of his recent races, but by the type of company in which he has been competing",
        "Dealing with say 50 teams and say 10 matches to rely on data pointing the way is problematic",
        "I still dismiss your quaint notion Blue Banners don't matter!",
        "I will refine, ask away its about assembling the best pick list, right? I have much to offer there.",
        "The single most important stat in horse racing is “class” don't under estimate that quality. I've learned from experience there.",
        "Don't use apps",
        "Look at music…CD/streaming are cheap and acceptabe, yet LP albums are purer.",
        "We have [a blue banner]…strive for more every season. Not for everyone and thats fine",
        "NOT season",
        "This thread is a no win scenario and should end for the good of the game. Mods shut it down.",
        "I me thinks get a lot of silent likes and that is a-ok there are still critical thinkers here.",
        "winner winner chicken dinner"
    };

    // Array of matches and the teams that are in them, used for QR generation.
    public static int[][] matchTeams = { new int[]{ 867,1661,7415,6814,114,5089 }, new int[]{ 580,973,691,8129,6934,2465 }, new int[]{ 8060,5285,7137,2659,2102,5818 }, new int[]{ 299,589,3863,3501,3309,3328 }, new int[]{ 696,359,3257,207,1159,4711 }, new int[]{ 115,4,4414,2584,1138,2429 }, new int[]{ 5869,6560,1678,4481,1388,5012 }, new int[]{ 691,7137,2659,973,4711,3863 }, new int[]{ 207,8060,8129,1138,299,867 }, new int[]{ 3309,6934,115,6814,1388,5285 }, new int[]{ 3501,3257,580,4481,1678,7415 }, new int[]{ 2429,359,4,1661,5012,2102 }, new int[]{ 5089,4414,1159,5818,114,589 }, new int[]{ 696,2465,5869,2584,3328,6560 }, new int[]{ 115,5285,299,359,2659,6934 }, new int[]{ 4414,207,973,3863,7415,5818 }, new int[]{ 2465,1678,3328,114,1661,1138 }, new int[]{ 589,5012,696,3309,580,8060 }, new int[]{ 3257,6814,2584,2102,691,6560 }, new int[]{ 7137,2429,1388,5089,4481,4711 }, new int[]{ 1159,5869,3501,8129,867,4 }, new int[]{ 3328,5818,115,359,3309,2465 }, new int[]{ 973,1138,8060,6814,4481,6560 }, new int[]{ 114,5012,3257,8129,5869,7137 }, new int[]{ 7415,2102,207,2659,696,1159 }, new int[]{ 1388,3863,6934,1661,2429,4414 }, new int[]{ 5089,1678,691,4,299,580 }, new int[]{ 3501,2584,4711,589,5285,867 }, new int[]{ 7415,6814,5012,3328,1159,3257 }, new int[]{ 114,2465,8060,4,3863,3309 }, new int[]{ 2584,115,4481,299,8129,5089 }, new int[]{ 5285,1661,5818,580,1138,696 }, new int[]{ 973,359,1678,5869,691,2429 }, new int[]{ 2659,867,4414,6560,7137,6934 }, new int[]{ 1388,4711,2102,589,3501,207 }, new int[]{ 6814,3863,359,2465,580,4481 }, new int[]{ 1138,2659,5869,5089,696,2429 }, new int[]{ 3257,589,8129,5285,6934,114 }, new int[]{ 4711,6560,115,1661,4,7137 }, new int[]{ 207,299,5012,867,973,2584 }, new int[]{ 7415,3328,691,1388,8060,1159 }, new int[]{ 4414,5818,3309,1678,3501,2102 }, new int[]{ 3863,5089,1138,4711,6934,3257 }, new int[]{ 2465,6560,4,2429,589,7415 }, new int[]{ 3309,1159,5285,4481,4414,691 }, new int[]{ 8060,5869,1661,115,3501,973 }, new int[]{ 1388,8129,2659,5012,5818,359 }, new int[]{ 207,2584,580,7137,3328,114 }, new int[]{ 299,1678,696,2102,6814,867 }, new int[]{ 6560,3309,1661,7415,4711,8129 }, new int[]{ 6934,589,4481,5818,207,5869 }, new int[]{ 114,2102,696,691,115,3863 }, new int[]{ 1138,4,1388,973,3257,299 }, new int[]{ 8060,2659,2429,1678,1159,2584 }, new int[]{ 3501,867,5089,359,3328,5285 }, new int[]{ 580,7137,5012,4414,2465,6814 }, new int[]{ 3257,1661,207,115,8060,589 }, new int[]{ 1138,3309,7415,5869,2584,359 }, new int[]{ 8129,580,6814,4,2659,3501 }, new int[]{ 4481,2429,5818,867,691,114 }, new int[]{ 4711,696,3328,6934,4414,1678 }, new int[]{ 7137,3863,1159,6560,1388,299 }, new int[]{ 5285,5089,2102,5012,973,2465 }, new int[]{ 3328,4481,2659,691,4,589 }, new int[]{ 1159,115,867,3863,580,5869 }, new int[]{ 2465,1138,7137,8060,7415,3501 }, new int[]{ 6560,973,5089,696,207,3309 }, new int[]{ 359,299,1661,4414,3257,5285 }, new int[]{ 5818,4711,6814,2429,5012,8129 }, new int[]{ 6934,2102,2584,1678,114,1388 }, new int[]{ 1159,359,589,7137,696,973 }, new int[]{ 691,5818,3501,5012,115,1138 }, new int[]{ 3309,867,1388,2659,3257,2465 }, new int[]{ 580,7415,114,299,2429,4711 }, new int[]{ 1678,5285,4,3863,6560,207 }, new int[]{ 6934,5869,6814,2584,8060,4414 }, new int[]{ 2102,8129,4481,3328,5089,1661 }, };
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
        bool isStudent = int.TryParse(username.Substring(0, 2), out _);
        if(!isStudent) 
            return username.Substring(0, 1).ToUpper() + username.Substring(1);
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

    public static string getBoltmanQuote() {
        int possibleQuotes = importantQuotes.Length * 3 + quotes.Length;
        int randomQuoteID = new System.Random().Next(possibleQuotes);

        if(randomQuoteID < importantQuotes.Length * 3) {
            return importantQuotes[randomQuoteID / 3];
        } else {
            return quotes[randomQuoteID - importantQuotes.Length * 3];
        }
    }
}
