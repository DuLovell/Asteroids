using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip : MonoBehaviour
{
    [SerializeField]
    Bullet bulletPrefab;

    bool isShootAxesInUse = false;

    const float thrustMoveForwardSpeed = 10;
    const float thrustRotateSpeed = 4;
    Rigidbody2D rigidSpaceShip;
    Collider2D colliderSpaceShip;

    float shipTopHalf;

    // Start is called before the first frame update
    void Start()
    {
        
        rigidSpaceShip = GetComponent<Rigidbody2D>();
        colliderSpaceShip = GetComponent<Collider2D>();

        shipTopHalf = colliderSpaceShip.bounds.extents.y;

        Physics2D.IgnoreLayerCollision(0, 0, true);

    }

    // Update is called once per frame
    void Update()
    {
        // physically thrust rigidSpaceShip along the direction of looking
        if (Input.GetAxis("Thrust") != 0)
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

        if (Input.GetAxis("Shoot") != 0)
        {
            if (isShootAxesInUse == false)
            {
                isShootAxesInUse = true;

                Vector2 positionBullet = transform.position;
                positionBullet.y += transform.up.y * shipTopHalf;
                positionBullet.x += transform.up.x * shipTopHalf;

                Bullet bullet = Instantiate(bulletPrefab, positionBullet, Quaternion.identity);
                bullet.Direction = transform.up;
                bullet.Rotation = transform.rotation;
            }
        }

        if (Input.GetAxis("Shoot") == 0)
        {
            isShootAxesInUse = false;
        }
    }
}
