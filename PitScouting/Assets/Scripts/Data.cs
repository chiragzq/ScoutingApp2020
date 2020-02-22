using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamData
{
    //team scene
    public int teamNumber;
    //robot scene
    public double roboHeight;
    public double roboWeight;
    public string roboDrivetrain;
    //scoring scene
    public string canScoreGoals;
    public string canClimb;
    public string canWheelSpin;
    //strategy scene
    public int autonStartWithBalls;
    public int autonScoreBalls;
    public string defenseStrat;
    public string pathStrat;
    //reliability scene
    public string roboStability;
    public string roboRobustness;
    //comments scene
    public string strengthsComments;
    public string weaknessesComments;
    public string generalComments;
}

public class Data : MonoBehaviour
{
    public static TeamData teamData = new TeamData();

    // Update is called once per frame
    void Update()
    {
        
    }
}
