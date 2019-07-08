using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipByVelocity : MonoBehaviour
{
    SpriteRenderer renderer;
    PlayerMovement movementScript;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        movementScript = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (movementScript.physics.velocity.x > 0.2f || movementScript.physics.velocity.x < -0.2f)
        {
            float rotation = (movementScript.physics.velocity.x < 0.0f) ? 180.0f :
                        (movementScript.physics.velocity.x > 0.0f) ? 0.0f :
                        transform.rotation.eulerAngles.y;

            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, rotation, transform.rotation.eulerAngles.z);
        }
    }
}
