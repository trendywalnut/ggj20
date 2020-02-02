using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerTether : MonoBehaviour
{
    public GameObject ship;
    public float increment;
    //acts as the radius of the circle
    public float maxRopeLength;
    public float moveSpeed;

    private Rigidbody2D myRigidBody;
    private Rigidbody2D shipRigidBody;


    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector2(ship.transform.position.x + 1, ship.transform.position.y);
        myRigidBody = GetComponent<Rigidbody2D>();
        shipRigidBody = GetComponent<Rigidbody2D>();
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
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Asteroid")
        {
            SceneManager.LoadScene("Game Over Screen");
        }
    }
}
