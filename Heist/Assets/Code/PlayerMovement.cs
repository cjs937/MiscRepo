using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public LayerMask collisionLayers;
    public LayerMask takeAwayLayers;
    public float friction = 1;
    public float gravity = 9.8f;
    public float speed;
    public Vector2 velocity = Vector2.zero;
    public float mass = 1;
    bool isGrounded = true;
    public Vector2 raycastDistance;
    Vector2 force;
    public float jumpForce;
    public float maxDoubleJumps;
    TakeawayCounters takeawayCounters = new TakeawayCounters();
    private void Update()
    {
        Vector2 moveForce = Vector2.zero;

        if (Input.GetKeyDown(KeyCode.W))
        {
            if (takeawayCounters.jumpCount <= maxDoubleJumps)
            {
                moveForce.y += jumpForce;

                velocity.y = 0;//-velocity.y;
                takeawayCounters.jumpCount++;
            }
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveForce.x -= speed;          
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            //velocity.y = 0;
            takeawayCounters.jumpCount--;

            if (takeawayCounters.jumpCount < 0)
                takeawayCounters.jumpCount = 0;
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveForce.x += speed;
        }

        addForce(moveForce);
    }

    private void FixedUpdate()
    {
        applyGravity();

        move(force);
    }

    void addForce(Vector2 _force)
    {
        force += _force; 
    }

    void move(Vector2 _forceVec)
    {
        Vector2 position = transform.position;

        _forceVec = applyFriction(_forceVec);

        Vector2 accel = _forceVec / mass;

        velocity += accel * Time.deltaTime;

        position += velocity * Time.deltaTime;

        RaycastResult positionCheck = checkRayCasts(position, ref isGrounded);

        debugCasts(position, positionCheck);

        if (isGrounded)
            takeawayCounters.jumpCount = 0;

        if (positionCheck.xLeft || positionCheck.xRight)
        {
            position.x = transform.position.x;

            velocity.x = 0;
        }

        if (positionCheck.yUp || positionCheck.yDown)
        {
            position.y = transform.position.y;

            velocity.y = 0;
        }

        transform.position = position;

        force = Vector2.zero;
    }

    Vector2 applyFriction(Vector2 _forceVec)
    {
        //if (!isGrounded)
        //    return _forceVec;

        float frictionX = -velocity.x * friction;

        _forceVec.x += frictionX;

        return _forceVec;
    }

    void applyGravity()
    {
        addForce(new Vector2(0, -gravity));
    }

    RaycastResult checkRayCasts(Vector2 positionVec, ref bool _isGrounded)
    {
        RaycastResult result;

        result.xLeft = Physics2D.Raycast(positionVec, Vector2.left, raycastDistance.x, collisionLayers);
        result.xRight = Physics2D.Raycast(positionVec, Vector2.right, raycastDistance.x, collisionLayers);
        result.yUp = Physics2D.Raycast(positionVec, Vector2.up, raycastDistance.y, collisionLayers);
        result.yDown = Physics2D.Raycast(positionVec, Vector2.down, raycastDistance.y, collisionLayers);

        _isGrounded = result.yDown;

        return result;
    }

    void debugCasts(Vector2 position, RaycastResult _result)
    {
        Color leftColor = _result.xLeft ? Color.red : Color.green;
        Color rightColor = _result.xRight ? Color.red : Color.green;
        Color upColor = _result.yUp ? Color.red : Color.green;
        Color downColor = _result.yDown? Color.red : Color.green;

        Debug.DrawLine(transform.position, transform.position + Vector3.left * raycastDistance.x, leftColor);
        Debug.DrawLine(transform.position, transform.position + Vector3.right * raycastDistance.x, rightColor);
        Debug.DrawLine(transform.position, transform.position + Vector3.up * raycastDistance.y, upColor);
        Debug.DrawLine(transform.position, transform.position + Vector3.down * raycastDistance.y, downColor);
    }

    private void OnTriggerEnter2D(Collider2D _collider)
    {
        if (takeAwayLayers.value == (takeAwayLayers.value | 1<< _collider.gameObject.layer))
        {
            takeawayCounters.Takeaway();
        }
    }
}

struct RaycastResult
{
    public RaycastHit2D xLeft;
    public RaycastHit2D xRight;
    public RaycastHit2D yUp;
    public RaycastHit2D yDown;
}

class TakeawayCounters
{
    public float jumpCount;
    public float dashCount;

    public TakeawayCounters()
    {
       jumpCount = 0;
       dashCount = 0;
    }

    public void Takeaway()
    {
        jumpCount--;
        dashCount--;
    }
}


//if(positionCheck.xLeft || positionCheck.xRight)
//{
//    if (positionCheck.xLeft)

//        position.x = (positionCheck.xLeft.normal * 0.5f).y;

//    else if (positionCheck.xRight)

//        position.x = (positionCheck.xRight.normal * 0.5f).y;

//    velocity.x = 0;
//}

//if (positionCheck.yUp || positionCheck.yDown)
//{
//    if(positionCheck.yUp)

//        position.y = (positionCheck.yUp.normal * 0.5f).y;

//    else if (positionCheck.yDown)

//        position.y = (positionCheck.yDown.normal * 0.5f).y;


//    velocity.y = 0;
//}