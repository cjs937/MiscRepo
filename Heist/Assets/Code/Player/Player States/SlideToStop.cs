using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideToStop : PlayerState
{
    public override void onEnter()
    {
        animHandler.animator.Play("Stop", 1, 0.0f);
        base.onEnter();
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();

        if (moveScript.dampVelocity())
            return;

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            nextState = new PlayerStateMoving();
        }
        else
            nextState = new PlayerStateIdle();
    }
}
