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

//<<<<<<< HEAD
    public AudioSource shipRepair;
    public AudioSource repairFail;
//=======
//>>>>>>> b8a276f6818179f4a50ba14a674b04734ae73df6

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
                repairFail.Play();
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

            heal.Repaired();

            shipRepair.Play();

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
                repairFail.Play();
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
}
