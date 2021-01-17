using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pusher : MonoBehaviour
{
    const float thrustMoveForwardSpeed = 4;
    const float thrustRotateSpeed = 3;
    Rigidbody2D rigidSpaceShip;

    // Start is called before the first frame update
    void Start()
    {
        
        rigidSpaceShip = GetComponent<Rigidbody2D>();
        

    }

    // Update is called once per frame
    void Update()
    {
        // physically thrust rigidSpaceShip along the direction of looking
        if (Input.GetAxis("Thrust") > 0)
        {
            rigidSpaceShip.AddForce(transform.up * thrustMoveForwardSpeed , ForceMode2D.Force); // transform.up - direction facing
        }

        // physically rotate rigidSpaceShip around z coordinate
        float inputRotate = Input.GetAxis("Rotate"); 
        if (inputRotate != 0)
        {
            //rigidSpaceShip.AddTorque(-inputRotate * thrustRotateSpeed, ForceMode2D.Force); // -inputRotate because .AddTorque rotates obj in clockwise direction
            
            // rotation without physics
            transform.Rotate(new Vector3(0, 0, -inputRotate * thrustRotateSpeed));
        }
    }
}
