using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroidSpawner : MonoBehaviour
{
    public Transform[] spawners;

    public GameObject asteroid;
    public List<GameObject> asteroids;

    private int randSpawn;
    public int numAsteroids;
    public int maxXForce;
    public int maxYForce;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("spawn");

        numAsteroids = Random.Range(2, 9);

        for (int i = 0; i < numAsteroids; i++)
        {
            randSpawn = Random.Range(0, 16);
            Instantiate(asteroid, spawners[randSpawn].position, Quaternion.identity);
            asteroids.Add(asteroid);
        }

        startMovement();

    }

    public void startMovement()
    {
        print("startMovement");
        foreach (GameObject gameObject in asteroids)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(200, 200));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
