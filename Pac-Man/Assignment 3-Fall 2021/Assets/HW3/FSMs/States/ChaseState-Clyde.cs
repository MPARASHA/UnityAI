using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseStateClyde : State
{
    //Set name of this state
    public ChaseStateClyde():base("Clyde-Chase"){ }

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
            return new ScatterState(new Vector3(-1 * ObstacleHandler.Instance.XBound, -1 * ObstacleHandler.Instance.YBound), this);
        }

        //If Pacman ate a power pellet, go to Frightened State
        if (PelletHandler.Instance.JustEatenPowerPellet)
        {
            return new FrightenedState(this);
        }
        
        Vector3 targetLocation = pacmanLocation;

        if (Vector3.Distance(pacmanLocation, agent.GetPosition()) < 1.6f)
        {
            targetLocation = new Vector3(-1 * ObstacleHandler.Instance.XBound, -1 * ObstacleHandler.Instance.YBound);
        }
        //If we didn't return follow Pacman
        agent.SetTarget(targetLocation);

        //Stay in this state
        return this;
    }

    //Upon entering state, set timer to enter Scatter State
    public override void EnterState(FSMAgent agent)
    {
        agent.SetTimer(20f);
    }

    public override void ExitState(FSMAgent agent){ }
}
