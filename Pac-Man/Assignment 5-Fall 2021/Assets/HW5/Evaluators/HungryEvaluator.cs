using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HungryEvaluator : Evaluator
{
    //Returns 0 if a level has no pellets, returns 1 for a level full of powerpellets
    public override float EvaluateLevel(Level level)
    {
        float percentagePellets = 0f;
        foreach(ProtoPellet p in level.pellets)
        {
            if (p.powerPellet)
            {
                percentagePellets += 1f;
            }
            else
            {
                percentagePellets += 0.5f;
            }
        }

        percentagePellets /= 350f;

        percentagePellets = Mathf.Clamp(percentagePellets, 0f, 1f);

        return percentagePellets;
    }
}
