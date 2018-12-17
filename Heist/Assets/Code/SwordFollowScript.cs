using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordFollowScript : MonoBehaviour
{
    public Camera cam = null;

    // Start is called before the first frame update
    void Start()
    {
        if (!cam)
            cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = getMousPos();
    }

    Vector2 getMousPos()
    {
        return cam.ScreenToWorldPoint(Input.mousePosition);
    }
}
