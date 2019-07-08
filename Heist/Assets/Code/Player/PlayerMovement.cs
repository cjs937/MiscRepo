using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public LayerMask collisionLayers;
    public float jumpForce;
    public float maxDoubleJumps;
    public bool canMove = true;
    public Rigidbody2D physics;
    public float moveSpeed;
    public float dampingSpeed;

    private void Start()
    {
        physics = GetComponent<Rigidbody2D>();

        GetComponent<StateHandler>().switchState(new PlayerStateIdle());
    }

    private void Update()
    {
       //Vector2 moveForce = Vector2.zero;
       //bool runAnim = false;
       //if (Input.GetKeyDown(KeyCode.W) && canMove)
       //{
       //
       //    if (takeawayCounters.jumpCount <= maxDoubleJumps)
       //    {
       //        moveForce.y += jumpForce;
       //
       //        velocity.y = 0;//-velocity.y;
       //        takeawayCounters.jumpCount++;
       //    }
       //}
       //if (Input.GetKey(KeyCode.A) && canMove)
       //{
       //    runAnim = true;
       //
       //    moveForce.x -= speed;          
       //}
       //if (Input.GetKeyDown(KeyCode.S))
       //{
       //    //velocity.y = 0;
       //    //takeawayCounters.jumpCount--;
       //
       //    //if (takeawayCounters.jumpCount < 0)
       //    //    takeawayCounters.jumpCount = 0;
       //
       //    takeawayCounters.Takeaway();
       //    animator.SetTrigger("stop");
       //}
       //if (Input.GetKey(KeyCode.D) && canMove)
       //{
       //    runAnim = true;
       //
       //    moveForce.x += speed;
       //}
       //
       //animator.SetBool("running", runAnim);
       //
       //addForce(moveForce);
    }

    //private void FixedUpdate()
    //{
    //    applyGravity();
    //
    //    move(force);
    //}

    public void move(Vector2 _direction, float moveSpeed)
    {
        Vector2 velocity = physics.velocity;

        velocity += _direction * moveSpeed * Time.deltaTime;

        physics.velocity = velocity;
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

    //void move(Vector2 _forceVec)
    //{
    //    Vector2 position = transform.position;
    //
    //    velocity = takeawayCounters.velocity;
    //
    //    _forceVec = applyFriction(_forceVec);
    //
    //    Vector2 accel = _forceVec / mass;
    //
    //    velocity += accel * Time.deltaTime;
    //
    //    position += velocity * Time.deltaTime;
    //
    //    RaycastResult positionCheck = checkRayCasts(position, ref isGrounded);
    //
    //    debugCasts(position, positionCheck);
    //
    //    if (isGrounded)
    //        takeawayCounters.jumpCount = 0;
    //
    //    if (positionCheck.xLeft || positionCheck.xRight)
    //    {
    //        position.x = transform.position.x;
    //
    //        velocity.x = 0;
    //    }
    //
    //    if (positionCheck.yUp || positionCheck.yDown)
    //    {
    //        position.y = transform.position.y;
    //
    //        velocity.y = 0;
    //    }
    //
    //    transform.position = position;
    //
    //    takeawayCounters.velocity = velocity;
    //
    //    force = Vector2.zero;
    //}

   //private void OnTriggerEnter2D(Collider2D _collider)
   //{
   //    if (takeAwayLayers.value == (takeAwayLayers.value | 1<< _collider.gameObject.layer))
   //    {
   //        takeawayCounters.Takeaway();
   //    }
   //}

    public void toggleMovement(int _canMove)//bool _canMove)
    {
        Debug.Log(_canMove);

        canMove = (_canMove > 0);

        Debug.Log(canMove);
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
    public Vector2 velocity;

    public TakeawayCounters()
    {
       jumpCount = 0;
       dashCount = 0;
    }

    public void Takeaway()
    {
        jumpCount--;
        if (jumpCount < 0)
            jumpCount = 0;

        dashCount--;

        if (dashCount < 0)
            dashCount = 0;

        velocity.x = 0.0f;

        if(velocity.y < 0)
            velocity.y = 0;
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