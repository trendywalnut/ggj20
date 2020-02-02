using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class testt : MonoBehaviour
{

    // author: Kamil104
    // http://answers.unity3d.com/users/225838/kamil1064.html
    public Image[] images; // imgaes to show which buton you need to press
    public KeyCode[] keys; // keys you need to press
    private float timer; // time which you have to press
    private float sorryTimer = 0;
    private int current;
    private int comboLength; // how many times you need to press correct key
    private int currentCombo = 0;

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
                print("wrong key was pressed");
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
            images[current].fillAmount = 0;
            print("you won :)");
            // do some stuff here
            gameObject.SetActive(false);
        }
        else
        {
            sorryTimer = Time.time + timer;
            images[current].fillAmount = 0;
            current = Random.Range(0, images.Length);
            if (!fastEnough)
            {
                print("You are too slow, you died");
                // and do die stuff here
                gameObject.SetActive(false);
            }
            else
                print("Nice");
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

