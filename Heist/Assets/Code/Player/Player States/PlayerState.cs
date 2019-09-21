using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : SubStateHandler
{
    public PlayerMovement moveScript;
    public AnimationHandler animHandler;
    public PlayerJump jumpScript;

    public override void init(StateHandler _handler)
    {
        base.init(_handler);

        moveScript = _handler.GetComponent<PlayerMovement>();
        animHandler = _handler.GetComponent<AnimationHandler>();
        jumpScript = _handler.GetComponent<PlayerJump>();
    }

    public virtual void handleMoveInput(float speed)
    {
        if (Input.GetKey(KeyCode.A))
        {
            moveScript.move(new Vector2(-1, 0), speed);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            moveScript.move(new Vector2(1, 0), speed);
        }
    }

}

public class PlayerSubState : SubState
{
    public PlayerState parentState;

    public override void init(SubStateHandler _parentState)
    {
        parentState = (PlayerState)_parentState;

        base.init(_parentState);
    }
}