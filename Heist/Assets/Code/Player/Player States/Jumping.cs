using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateJumping : PlayerState
{
    public override void onEnter()
    {
        base.onEnter();

        switchSubState(new JumpRise());
    }

    void handleInput()
    {
        if (Input.GetKey(KeyCode.A))
        {
            moveScript.move(new Vector2(-1, 0), moveScript.midJumpMoveSpeed);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            moveScript.move(new Vector2(1, 0), moveScript.midJumpMoveSpeed);
        }
    }

    public override void onExit()
    {
        animHandler.animator.Play("Idle");
        jumpScript.StartJumpReset();
        base.onExit();
    }
}


public class JumpStartup : PlayerSubState
{
    float delayTimer;

    public override void onEnter()
    {
        delayTimer = parentState.jumpScript.jumpStartupDelay;
        parentState.animHandler.animator.Play("JumpStartup");
        base.onEnter();
    }

    public override SubState update()
    {
        delayTimer -= Time.deltaTime;

        if (delayTimer <= 0)
        {
            return new JumpRise();
        }

        return base.update();
    }
}


public class JumpRise : PlayerSubState
{
    float checkDelay;

    public override void onEnter()
    {
        parentState.animHandler.animator.Play("JumpRise");
        parentState.jumpScript.inRise = true;

        parentState.jumpScript.BeginJump();

        checkDelay = parentState.jumpScript.groundCheckDelay;
        base.onEnter();
    }

    public override SubState update()
    {
        checkDelay -= Time.deltaTime;

        if (checkDelay <= 0 && parentState.moveScript.isGrounded())
        {
            if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
                parentState.switchParentState(new PlayerStateMoving());
            else
                return new JumpLand();
        }
        else if(!parentState.jumpScript.inRise)
        {
            return new JumpFall();
        }

        return base.update();
    }

    public override void FixedUpdate()
    {
        parentState.handleMoveInput(parentState.moveScript.midJumpMoveSpeed);

        if (parentState.moveScript.physics.velocity.y > 0 && !Input.GetKey(KeyCode.W))
        {
            parentState.jumpScript.UpdateJump();
        }
        else
        {
            parentState.jumpScript.Fall();
        }


        base.FixedUpdate();
    }

    public override void onExit()
    {
        parentState.jumpScript.inRise = false;
        base.onExit();
    }
}


public class JumpFall : PlayerSubState
{
    public override void onEnter()
    {
        parentState.animHandler.animator.Play("JumpFall");
        base.onEnter();
    }

    public override SubState update()
    {
        if (parentState.moveScript.isGrounded())
        {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
                parentState.switchParentState(new PlayerStateMoving());
            else
                return new JumpLand();
        }

        return base.update();
    }

    public override void FixedUpdate()
    {
        parentState.jumpScript.Fall();

        parentState.handleMoveInput(parentState.moveScript.midJumpMoveSpeed);

        base.FixedUpdate();
    }
}

public class JumpLand : PlayerSubState
{
    float landTimer;

    public override void onEnter()
    {
        parentState.animHandler.animator.Play("JumpLand");
        landTimer = parentState.jumpScript.landingDelay;

        base.onEnter();
    }

    public override SubState update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
            parentState.switchParentState(new PlayerStateMoving());

        landTimer -= Time.deltaTime;

        if (landTimer <= 0)
        {
            parentState.switchParentState(new PlayerStateIdle());
        }

        return base.update();
    }
}
