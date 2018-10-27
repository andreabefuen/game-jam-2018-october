using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    Light theLight;
    CapsuleCollider col;
    Rigidbody rBody;
    float speed = 10.0f;
    Vector3 velocity;
    float sizer;
    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody>();
        col = GetComponent<CapsuleCollider>();
        theLight = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        velocity.x = Input.GetAxis("Horizontal");
        velocity.y = Input.GetAxis("Vertical");
        rBody.velocity = transform.TransformDirection(velocity * speed);
        sizer = Input.GetAxis("SetSize");
        if (theLight.spotAngle < 75 && sizer > 0 || theLight.spotAngle > 20 && sizer < 0)
        {
            theLight.spotAngle += sizer;
            col.radius += sizer * 0.16f;
        }
    }
}
