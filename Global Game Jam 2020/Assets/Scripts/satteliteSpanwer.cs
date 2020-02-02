using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class satteliteSpanwer : MonoBehaviour
{

    public GameObject sat;
    public Transform[] spawners;

    public int randSpawn;
    //public int randSat;
    
    // Start is called before the first frame update
    void Start()
    {
        randSpawn = Random.Range(0, spawners.Length);
        //randSat = Random.Range(0, sats.Length);

        Instantiate(sat, spawners[randSpawn].position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
