﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pinky : FSMAgent
{

    void Start()
    {
        Initialize();//remove, this is testing
    }

    public override void Initialize()
    {
        currState = new ChaseStatePinky();
        currState.EnterState(this);
    }
}