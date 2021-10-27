using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseStateCustom : State
{
    //Set name of this state
    public ChaseStateCustom():base("Chase-Custom"){ }

    public override State Update(FSMAgent agent)
    {
        //Handle Following Pacman
        Vector3 pacmanLocation = PacmanInfo.Instance.transform.position;
        if (agent.CloseEnough(pacmanLocation))
        {
            ScoreHandler.Instance.KillPacman();
        }

        //If timer complete, go to Scatter State
        if (agent.TimerComplete())
        {   
            // Scatter around center
            return new ScatterStateCustom(new Vector3(0, 0), this);
        }

        //If Pacman ate a power pellet, go to Frightened State
        if (PelletHandler.Instance.JustEatenPowerPellet)
        {
            return new FrightenedStateCustom(this);
        }

        if (!ObstacleHandler.Instance.AnyIntersect(pacmanLocation, agent.GetPosition()))
        {
            return new SprintStateCustom();
        }
        //If we didn't return follow Pacman
        agent.SetTarget(pacmanLocation);

        //Stay in this state
        return this;
    }

    //Upon entering state, set timer to enter Scatter State
    public override void EnterState(FSMAgent agent)
    {
        agent.SetTimer(20f);
        agent.SetSpeedModifierNormal();
    }

    public override void ExitState(FSMAgent agent){ }
}
