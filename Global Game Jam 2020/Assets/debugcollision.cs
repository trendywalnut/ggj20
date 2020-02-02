using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class debugcollision : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
    }

}
