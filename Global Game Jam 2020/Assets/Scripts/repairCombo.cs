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
}
