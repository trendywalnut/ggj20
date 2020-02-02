using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class repairCombo : MonoBehaviour
{

    public Image[] images;
    public KeyCode[] keys;
    private float timer;
    private float sorryTimer = 0;
    private int current;
    private int comboLength;
    private int currentCombo = 0;

    public Health heal;
    
    // Update is called once per frame
    void Update()
    {
        if (Time.time > sorryTimer)
        {
            SetTimer(false);
        }
        if (Input.anyKeyDown)
        {
            //check for if element 0 is up on D-Pad returns true, and so on
            //can either do in the long way wit h4 if loops checking each value of Dpad against current value of current
            //or do something short and clever?
            //worst case we switch to bumpers and update the controls graphic
            if (Input.GetKeyDown(keys[current]))
            {
                SetTimer(true);
            }
            else
            {
                print("bruh");
                gameObject.SetActive(false);
            }
        }

        images[current].fillAmount = (sorryTimer - Time.time) / timer;
        
    }

    public void SetTimer(bool fastEnough)
    {
        images[current].gameObject.SetActive(false);
        if (currentCombo >= comboLength)
        {
            images[current].fillAmount = 1;
            print("pog");
            //insert repair
            //GetComponent<Health>().Repaired();

            heal.Repaired();

            heal.CurrentHealth = heal.MaxHealth;
            gameObject.SetActive(false);
        }
        else
        {
            sorryTimer = Time.time + timer;
            images[current].fillAmount = 1;
            current = Random.Range(0, images.Length);
            if (!fastEnough)
            {
                print("cheez-nuts");
                //insert die function
                gameObject.SetActive(false);
            }
            else
            
                print("nice");
                currentCombo++;
                images[current].gameObject.SetActive(true);
            
        }     
    }

    public void SetUpGame(float my_timer, int my_comboLength)
    {
        timer = my_timer;
        comboLength = my_comboLength;
        sorryTimer = Time.time + timer;
        currentCombo = 1;
        images[current].gameObject.SetActive(true);
    }

    public class Dpad
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
}
