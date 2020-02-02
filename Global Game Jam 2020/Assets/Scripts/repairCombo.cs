using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class repairCombo : MonoBehaviour
{

    public Image[] images;
    public KeyCode[] keys;
    private float timer;
    private float sorryTimer = 0;
    private int current;
    private int comboLength;
    private int currentCombo = 0;
    private bool satellite = false;
    private int sceneIndex;

    public AudioSource shipRepair;
    public AudioSource repairFail;

    public Health heal;

    void Start()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

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
            //insert repair
            if (satellite)
            {
                SceneManager.LoadScene(sceneIndex + 1);
            }
            else
            {
                heal.Repaired();
                shipRepair.Play();

                heal.CurrentHealth = heal.MaxHealth;
                gameObject.SetActive(false);
            }
 
        }
        else
        {
            sorryTimer = Time.time + timer;
            images[current].fillAmount = 1;
            current = Random.Range(0, images.Length);
            if (!fastEnough)
            {
                repairFail.Play();
                //insert die function

                gameObject.SetActive(false);
            }
            else
                currentCombo++;
                images[current].gameObject.SetActive(true);
    
        }
    }

    public void SetUpGame(float my_timer, int my_comboLength, bool isSatellite)
    {
        timer = my_timer;
        comboLength = my_comboLength;
        sorryTimer = Time.time + timer;
        currentCombo = 1;
        images[current].gameObject.SetActive(true);
        satellite = isSatellite;
    }
}
