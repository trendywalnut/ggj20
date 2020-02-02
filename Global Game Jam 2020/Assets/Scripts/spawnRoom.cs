using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnRoom : MonoBehaviour
{

    public LayerMask whatIsRoom;
    public levelGeneration levelGen;

    // Update is called once per frame
    void Update()
    {

        Collider2D roomdetection = Physics2D.OverlapCircle(transform.position, 1, whatIsRoom);
        if(roomdetection == null && levelGen.stopGeneration == true)
        {
            //Spawn Random Room
            int rand = Random.Range(0, levelGen.rooms.Length);
            Instantiate(levelGen.rooms[rand], transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

    }
}
