using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : SubStateHandler
{
    protected PlayerMovement moveScript;
    protected AnimationHandler animHandler;

    public override void init(StateHandler _handler)
    {
        base.init(_handler);

        moveScript = _handler.GetComponent<PlayerMovement>();
        animHandler = _handler.GetComponent<AnimationHandler>();
    }
}

public class PlayerSubState : SubState
{
    PlayerState parentState;

    public override void init(SubStateHandler _parentState)
    {
        parentState = (PlayerState)_parentState;

        base.init(_parentState);
    }
}