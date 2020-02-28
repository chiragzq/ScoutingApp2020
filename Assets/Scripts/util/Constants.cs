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
    public const string versionString = "Version 1.2.0 (Scouter Training)";

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
    public static readonly int[][] matchTeams = {new int[]{ 3082,7048,5998,3042,8002,4607 }, new int[]{ 2239,3299,3871,3313,5913,4663 }, new int[]{ 2450,3297,876,2500,2227,5658 }, new int[]{ 1619,4648,3926,3300,3007,3206 }, new int[]{ 4239,2549,3750,5172,4536,877 }, new int[]{ 7858,7028,4360,3277,7532,4506 }, new int[]{ 4539,8255,4593,2977,2847,8188 }, new int[]{ 6707,7677,5638,8298,7257,2472 }, new int[]{ 2129,5653,2654,2883,1792,3130 }, new int[]{ 7578,5929,6175,3298,4198,3293 }, new int[]{ 3206,2239,3297,4239,4360,4506 }, new int[]{ 7532,4648,3313,4663,4593,2450 }, new int[]{ 3042,4536,7048,7677,876,4539 }, new int[]{ 3871,5658,5913,3750,6707,2654 }, new int[]{ 4607,7578,2847,8002,1792,5172 }, new int[]{ 2977,8298,3277,6175,3299,5653 }, new int[]{ 8188,3130,3300,2227,7858,3293 }, new int[]{ 7028,2883,3007,5929,2472,4198 }, new int[]{ 3926,877,5998,3298,8255,5638 }, new int[]{ 3082,7257,1619,2549,2500,2129 }, new int[]{ 6175,2847,3042,4648,2654,4506 }, new int[]{ 3299,5172,7532,6707,876,3206 }, new int[]{ 1792,2977,3293,2239,8298,4536 }, new int[]{ 4198,5638,3313,8188,4239,3297 }, new int[]{ 8255,3300,2883,3871,2549,4607 }, new int[]{ 2227,5913,4593,7578,7028,2129 }, new int[]{ 4360,7257,5998,3007,3130,4539 }, new int[]{ 5929,5658,877,7858,3082,5653 }, new int[]{ 3277,2500,4663,8002,3298,3926 }, new int[]{ 2472,7048,7677,2450,3750,1619 }, new int[]{ 4593,4506,876,3293,2883,5638 }, new int[]{ 2549,4539,1792,3206,6175,7028 }, new int[]{ 877,4607,4360,3299,2654,4536 }, new int[]{ 7858,3300,8002,7257,6707,4239 }, new int[]{ 2472,3313,3130,2847,3926,3082 }, new int[]{ 8255,7578,2500,4663,5653,7048 }, new int[]{ 3750,3277,8188,7532,5998,3007 }, new int[]{ 5658,2129,4198,4648,2239,7677 }, new int[]{ 8298,5913,1619,3297,3042,5929 }, new int[]{ 2227,5172,2450,3871,2977,3298 }, new int[]{ 2500,3300,2472,4539,7578,3299 }, new int[]{ 1792,4663,3750,876,8188,4360 }, new int[]{ 7048,7028,4239,3293,5658,3007 }, new int[]{ 2549,2654,2239,5929,4593,3277 }, new int[]{ 3042,4198,6707,3926,2450,5653 }, new int[]{ 5638,4536,2129,2847,7532,3871 }, new int[]{ 1619,4506,3130,877,2977,8002 }, new int[]{ 5913,3206,7677,4607,2227,8255 }, new int[]{ 8298,3298,7858,3313,2883,3082 }, new int[]{ 7257,6175,4648,5998,3297,5172 }, new int[]{ 3300,2450,3299,2847,5638,5929 }, new int[]{ 3926,2977,7578,5658,7532,4239 }, new int[]{ 3206,3293,4663,7677,877,3042 }, new int[]{ 4607,1619,2500,2239,3313,7028 }, new int[]{ 3298,3277,4536,3130,4648,6707 }, new int[]{ 4506,5653,2883,5913,5998,8188 }, new int[]{ 3297,3871,1792,3007,7048,7858 }, new int[]{ 4198,3750,2227,2654,4539,7257 }, new int[]{ 8255,876,6175,2129,3082,2472 }, new int[]{ 8002,4360,8298,5172,2549,4593 }, new int[]{ 7028,3293,6707,4663,5998,2847 }, new int[]{ 5658,1792,3299,1619,3298,3042 }, new int[]{ 2450,7578,2239,8188,877,7257 }, new int[]{ 3297,2129,4607,5653,3277,4539 }, new int[]{ 876,3926,5913,2977,7858,2549 }, new int[]{ 4360,7677,3130,6175,3871,2500 }, new int[]{ 5638,3206,8002,2883,5929,3750 }, new int[]{ 4198,3007,3082,4536,4593,3300 }, new int[]{ 2654,8255,7532,4239,4648,8298 }, new int[]{ 7048,2227,3313,5172,4506,2472 }, new int[]{ 5653,2847,3298,7257,2239,876 }, new int[]{ 7677,8002,2883,3299,3926,3297 }, new int[]{ 6707,4663,877,3007,2129,6175 }, new int[]{ 7532,8298,4198,3130,4607,5658 }, new int[]{ 2654,5172,7858,7028,1619,8255 }, new int[]{ 4593,2472,3871,5998,3206,1792 }, new int[]{ 3293,3082,4239,4539,2450,5913 }, new int[]{ 4506,8188,2227,4536,2500,5929 }, new int[]{ 3313,3042,2977,3750,4360,3300 }, new int[]{ 4648,3277,2549,7048,5638,7578 }, new int[]{ 3130,3297,7257,3299,4663,8255 }, new int[]{ 877,4539,7028,876,3871,8298 }, new int[]{ 5913,3293,5172,2500,4198,1792 }, new int[]{ 4506,4607,2450,4593,3750,3926 }, new int[]{ 2883,4239,2847,3277,1619,2227 }, new int[]{ 3007,3042,7578,5638,7858,2239 }, new int[]{ 3082,5929,4648,4360,6707,2977 }, new int[]{ 5653,2472,7532,3300,7677,2549 }, new int[]{ 2654,3298,3206,2129,8188,7048 }, new int[]{ 5998,8002,6175,4536,3313,5658 } };
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
