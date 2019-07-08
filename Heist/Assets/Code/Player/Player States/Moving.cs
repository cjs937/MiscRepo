using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMoving : PlayerState
{
    public override void FixedUpdate()
    {
        handleInput();

        base.FixedUpdate();
    }

    public override void onEnter()
    {
        base.onEnter();

        animHandler.animator.SetBool("running", true);
    }

    void handleInput()
    {
        if (Input.GetKey(KeyCode.A))
        {
            moveScript.move(new Vector2(-1, 0), moveScript.moveSpeed);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            moveScript.move(new Vector2(1, 0), moveScript.moveSpeed);
        }
        else
            nextState = new PlayerStateIdle();
    }

    public override void onExit()
    {
        base.onExit();

        animHandler.animator.SetBool("running", false);
    }
}
