using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateIdle : PlayerState 
{

    public override void onEnter()
    {
        animHandler.animator.Play("Idle", 0, 0.0f);
        base.onEnter();
    }

    public override CustomState update()
    {

        return base.update();
    }

    public override void FixedUpdate()
    {
        handleInput();

        base.FixedUpdate();
    }
      
    void handleInput()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            nextState = new PlayerStateMoving();
        }
    }
}
