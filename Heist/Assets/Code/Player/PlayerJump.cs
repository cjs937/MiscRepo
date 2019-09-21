using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public float jumpForce;
    public float lowJumpMultiplier;
    public float fallGravity;
    public float jumpStartupDelay;
    public float groundCheckDelay;
    public float landingDelay;
    public float delayBetweenJumps;

    [HideInInspector]
    public bool inRise;
    [HideInInspector]
    public bool resetting;
    Rigidbody2D physics;
    float jumpResetTimer;

    private void Start()
    {
        physics = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(resetting)
        {
            jumpResetTimer -= Time.deltaTime;

            if (jumpResetTimer <= 0)
                resetting = false;
        }
    }

    public void BeginJump()
    {
        physics.velocity += (Vector2)transform.up * jumpForce;
    }

    public void UpdateJump()
    {
        physics.velocity += (Vector2)transform.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
    }

    public void Fall()
    {
        physics.velocity += (Vector2)transform.up * Physics.gravity.y * (fallGravity - 1) * Time.deltaTime;
    }

    public void EndRise()
    {
        inRise = false;
    }

    public void StartJumpReset()
    {
        resetting = true;
        jumpResetTimer = delayBetweenJumps;
    }
}
