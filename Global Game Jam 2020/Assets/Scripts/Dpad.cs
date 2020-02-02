using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dpad : MonoBehaviour
{
    private float dpadX;
    private float dpadY;
    public bool leftDpadPressed;
    public bool rightDpadPressed;
    public bool upDpadPressed;
    public bool downDpadPressed;
    private bool currentlyReleased;

    private void Start()
    {
        currentlyReleased = true;
    }

    private void Update()
    {
        dpadX = Input.GetAxis("Dpad X");
        dpadY = Input.GetAxis("Dpad Y");



        if (dpadX == -1)
        {
            leftDpadPressed = true;
            if (leftDpadPressed && currentlyReleased)
            {
                //Fire events

                Debug.Log("LEFT");
            }

            currentlyReleased = false;
        }
        if (dpadX == 1)
        {
            rightDpadPressed = true;
            if (rightDpadPressed && currentlyReleased)
            {
                //Fire events

                Debug.Log("RIGHT");
            }
            currentlyReleased = false;
        }
        if (dpadY == -1)
        {
            downDpadPressed = true;
            if (downDpadPressed && currentlyReleased)
            {
                //Fire events

                Debug.Log("DOWN");
            }
            currentlyReleased = false;
        }
        if (dpadY == 1)
        {
            upDpadPressed = true;
            if (upDpadPressed && currentlyReleased)
            {
                //Fire events

                Debug.Log("UP");
            }
            currentlyReleased = false;
        }
        if (dpadY == 0 && dpadX == 0)
        {
            upDpadPressed = false;
            downDpadPressed = false;
            leftDpadPressed = false;
            rightDpadPressed = false;
            currentlyReleased = true;
        }

    }
}
