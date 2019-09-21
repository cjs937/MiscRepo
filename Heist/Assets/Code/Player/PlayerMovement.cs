using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    public bool canMove = true;
    public Rigidbody2D physics;
    public float moveSpeed;
    public float midJumpMoveSpeed;
    public float dampingSpeed;

    public LayerMask groundCheckLayers;
    public float groundCheckDistance;

    private void Start()
    {
        physics = GetComponent<Rigidbody2D>();

        GetComponent<StateHandler>().switchState(new PlayerStateIdle());
    }

    public void move(Vector2 _direction, float moveSpeed)
    {
        Vector2 velocity = physics.velocity;

        velocity += _direction * moveSpeed * Time.deltaTime;

        physics.velocity += _direction * moveSpeed * Time.deltaTime;//velocity;
    }

    public bool dampVelocity()
    {
        if (physics.velocity.x > 0.2f || physics.velocity.x < -0.2f)
        {
            physics.velocity += new Vector2(-Mathf.Sign(physics.velocity.x) * dampingSpeed * Time.deltaTime, 0);

            return true;
        }

        return false;
    }

    public bool isGrounded()
    {
        Color lineColor = Color.green;

        bool hit = Physics2D.Raycast(transform.position, -transform.up, groundCheckDistance, groundCheckLayers);

        if (hit)
        {
            lineColor = Color.red;
        }

        Debug.DrawLine(transform.position, transform.position + -transform.up * groundCheckDistance, lineColor);

        return hit;
    }   

    public void toggleMovement(int _canMove)//bool _canMove)
    {
        Debug.Log(_canMove);

        canMove = (_canMove > 0);

        Debug.Log(canMove);
    }
}