using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrightenedStateCustom : State
{
    //State to return to once complete
    private State returnState;

    //Random timer for handling random movement
    private float randomTimer = 0;
    private const float RANDOM_TIMER_MAX = 0.5f;

    //Constructor, set up name of state
    public FrightenedStateCustom(State _returnState): base("Frightened-Custom")
    {
        returnState = _returnState;
    }

   
    public override State Update(FSMAgent agent)
    {
        //Check and see if we've been eaten, if so become eyes
        Vector3 pacmanLocation = PacmanInfo.Instance.transform.position;
        if (agent.CloseEnough(pacmanLocation))
        {
            return new EyesState(returnState);
        }

        //Check and see if our timer completed, if so return to returnState
        if (agent.TimerComplete())
        {
            return returnState;
        }

        //Handle random movement
        if (randomTimer < RANDOM_TIMER_MAX)
        {
            randomTimer += Time.deltaTime;
        }
        else
        {
            randomTimer = 0;
            agent.SetTarget(new Vector3(Random.RandomRange(-1 * ObstacleHandler.Instance.XBound, ObstacleHandler.Instance.XBound), Random.RandomRange(-1 * ObstacleHandler.Instance.YBound, ObstacleHandler.Instance.YBound)));
        }
        //Stay in this state
        return this;
    }

    //Upon entering state, start a timer, set speed modifier to half, and set up animations
    public override void EnterState(FSMAgent agent)
    {
        agent.SetAnimationStateFrightened();
        agent.SetSpeedModifierHalf();

        // Frightened state which is over quicker. Brave Ghost.
        agent.SetTimer(6);
    }

    //Upon exiting state, set speed and animation state to normal
    public override void ExitState(FSMAgent agent)
    {
        agent.SetAnimationStateNormal();
        agent.SetSpeedModifierNormal();
    }
}
