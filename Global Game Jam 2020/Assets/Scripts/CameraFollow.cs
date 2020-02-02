using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //allows for the correct gameobject that the camera should follow to be set from the inspector
    public Transform trackedObject;

    //Camera's position is tied to the center of the player's position
    //updates every frame
    void Update()
    {
        transform.position = new Vector3(trackedObject.position.x, trackedObject.position.y, transform.position.z);
    }
}
