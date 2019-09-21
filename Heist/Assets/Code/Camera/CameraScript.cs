using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject player;
    public float followSpeed;
    public Vector3 camOffset;
    Transform cameraMask;

    private void Start()
    {
        if(!player)
        {
            player = GameObject.FindObjectOfType<PlayerMovement>().gameObject;
        }

        cameraMask = new GameObject("Camera Mask").transform;
    }

    private void Update()
    {
        cameraMask.position = player.transform.position + camOffset;
        transform.position = Vector3.Lerp(transform.position, cameraMask.position, Time.deltaTime * followSpeed);
    }
}
