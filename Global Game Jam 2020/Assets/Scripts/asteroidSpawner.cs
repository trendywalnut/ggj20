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
    public int maxAsteroids;
    public int maxXForce;
    public int maxYForce;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("spawn");
        numAsteroids = Random.Range(2, maxAsteroids + 1);
        startMovement();

    }

    public void createAsteroids(int initialXVelocity, int initialYVelocity)
    {
        for (int i = 0; i < numAsteroids; i++)
        {
            randSpawn = Random.Range(0, spawners.Length);
            GameObject dummy = Instantiate(asteroid, spawners[randSpawn].position, Quaternion.identity);
            print(dummy.GetComponent<Rigidbody2D>().velocity);
            dummy.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-initialXVelocity, initialXVelocity + 1), Random.Range(-initialYVelocity, initialYVelocity + 1));
            asteroids.Add(asteroid);
        }
    }

    public void startMovement()
    {
        print("startMovement");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
