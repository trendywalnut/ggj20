using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionChange : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Transition");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Transition()
    {
        yield return new WaitForSeconds(3);
        GetComponent<SpriteRenderer>().enabled = false;
    }
}
