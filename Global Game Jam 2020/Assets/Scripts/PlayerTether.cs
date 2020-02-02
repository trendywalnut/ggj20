using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTether : MonoBehaviour
{
    public GameObject ship;
    public float increment;
    //acts as the radius of the circle
    public float maxRopeLength;
    public float moveSpeed;

    private Rigidbody2D myRigidBody;
    private Rigidbody2D shipRigidBody;
    //private float distanceFromShip;
    //private float currRopeLength;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector2(ship.transform.position.x + 1, ship.transform.position.y);
        myRigidBody = GetComponent<Rigidbody2D>();
        shipRigidBody = GetComponent<Rigidbody2D>();
        //float xDiff = Mathf.Pow(ship.transform.position.x - transform.position.x, 2);
        //float yDiff = Mathf.Pow(ship.transform.position.y - transform.position.y, 2);
        //currRopeLength = Mathf.Sqrt(xDiff + yDiff);
    }

    // Update is called once per frame
    void Update()
    {
        //allows astronaut to move omnidirectionally but within the bounds of the length of the tether
        if((Input.GetAxis("Vertical") > 0 || Input.GetKey(KeyCode.I)) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.UpArrow))
        {
            myRigidBody.AddForce(transform.up * moveSpeed);
        }
        if((Input.GetAxis("Vertical") < 0 || Input.GetKey(KeyCode.K)) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.DownArrow))
        {
            myRigidBody.AddForce(transform.up * -moveSpeed);
        }
        if((Input.GetAxis("Horizontal") < 0 || Input.GetKey(KeyCode.J)) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.LeftArrow))
        {
            myRigidBody.AddForce(transform.right * -moveSpeed);
        }
        if((Input.GetAxis("Horizontal") > 0 || Input.GetKey(KeyCode.L)) && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.RightArrow))
        {
            myRigidBody.AddForce(transform.right * moveSpeed);
        }
        //if(distanceFromShip >= ropeLength)
        //{
        //transform.position = Vector2.Lerp(transform.position, ship.transform.position, .01f);
        //}
        //increases tether up to max length specified if button is pressed
        //if (Input.GetKey(KeyCode.JoystickButton2) && currRopeLength < maxRopeLength)
        //{
            //currRopeLength += increment;
        //}

        
        //keeps the astronaut within the vicinity of the ship by keeping transform data consistent

        //calculates the distance of the astronaut from the ship each frame
        //float xDiff = Mathf.Pow(ship.transform.position.x - transform.position.x, 2);
        //float yDiff = Mathf.Pow(ship.transform.position.y - transform.position.y, 2);
        //distanceFromShip = Mathf.Sqrt(xDiff + yDiff);
        //Debug.Log(currRopeLength);
        //Debug.Log(distanceFromShip);
    }
}
