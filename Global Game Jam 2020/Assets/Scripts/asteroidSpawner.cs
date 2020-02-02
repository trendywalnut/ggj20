using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroidSpawner : MonoBehaviour
{
    public Transform[] spawners;

    public GameObject asteroid;
    public List<GameObject> asteroids;

    private int randSpawn;
    private int numAsteroids;
    public int maxXForce;
    public int maxYForce;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("spawn");
        numAsteroids = Random.Range(1, 7);
        for (int i = 0; i < numAsteroids; i++)
        {
            randSpawn = Random.Range(1, 17);
            Instantiate(asteroid, spawners[randSpawn].position, Quaternion.identity);
            asteroids.Add(asteroid);
        }

        startMovement();

    }

    public void startMovement()
    {
        print("startMovement");
        for(int i = 0; i < numAsteroids; i++)
        {
            float randX = Random.Range(1, maxXForce);
            float randY = Random.Range(1, maxYForce);
            Rigidbody2D rb = asteroids[i].GetComponent<Rigidbody2D>();
            //Vector2 moveForce = new Vector2(250, 250);
            rb.velocity = new Vector2(200, 200);
            print(randX);
            print(randY);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
