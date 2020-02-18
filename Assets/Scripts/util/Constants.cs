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
    public const string versionString = "Version 1.0.1 (Scouter Training)";

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
