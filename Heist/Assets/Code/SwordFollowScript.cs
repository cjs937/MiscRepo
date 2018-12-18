using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordFollowScript : MonoBehaviour
{
    //public Camera cam = null;

    public PlayerMovement player;
    public Transform movePos;
    public float moveSpeed;
    public float rotateSpeed;

    void Update()
    {
        transform.position = getPositionByPlayer();

        transform.rotation = getRotationByPlayer();
    }

    Vector2 getPositionByPlayer()
    {

        return Vector2.Lerp(transform.position, movePos.position, moveSpeed * Time.deltaTime);
    }

    Quaternion getRotationByPlayer()
    {
        Vector3 lookPos = player.transform.position - transform.position;
        lookPos.Normalize();

        float rot_z = Mathf.Atan2(lookPos.y, -lookPos.x) * Mathf.Rad2Deg;

        Quaternion rotation = Quaternion.Euler(0f, 0f, rot_z + 90);

        return Quaternion.Slerp(transform.rotation, rotation, rotateSpeed * Time.deltaTime);
    }
}
