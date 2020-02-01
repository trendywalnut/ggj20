using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    //15 seems to be good...? Depends on the scale of the game
    public float moveSpeed;
    //125 seems good...? Depends on the size of the ship
    public float turnSpeed;

    private Rigidbody2D myRigidBody;

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //move in the direction the ship is pointing at the current speed specified by moveSpeed
        if (Input.GetKey(KeyCode.W))
        {
            myRigidBody.AddForce(transform.up * moveSpeed);
        }
        //Rotates along the Z-axis (positively or negatively) depending on key pressed
        else if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, 0, turnSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, 0, -turnSpeed * Time.deltaTime);
        }
    }
}
