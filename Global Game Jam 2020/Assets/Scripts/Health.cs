using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Image[] images;
    public KeyCode[] keys;
    private float timer;
    private float sorryTimer = 0;
    private int current;
    private int comboLength;
    private int currentCombo = 0;
    public float CurrentHealth { get; set; }
    public float MaxHealth { get; set; }

    private bool isBroken;

    public Slider healthBar;
    void Start()
    {
        MaxHealth = 1000f;
        CurrentHealth = MaxHealth;

        healthBar.value = CalaculateHealth();
    }

    // Update is called once per frame
    void Update()
    {
        DealDamage();

        //if (Input.GetKeyDown(KeyCode.Z))
        //{

        //    Broken();
            
        //}
        //if (Input.GetKeyDown(KeyCode.X))
        //{
        //    Repaired();
        //}

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

    void Repaired()
    {
        isBroken = false;
    }
    void Broken()
    {
        isBroken = true;
    }
    void DealDamage ()
    {
        if (isBroken == true)
        {
            //CurrentHealth -= damageValue;
            CurrentHealth--;
            healthBar.value = CalaculateHealth();
            if (CurrentHealth <= 0)
            {
                Die();
            }
        }
    }

    float CalaculateHealth()
    {
        return CurrentHealth / MaxHealth;
    }

    void Die()
    {
        CurrentHealth = 0;
        Debug.Log("cheez nuts");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Broken();
    }

    public void SetTimer(bool fastEnough)
    {
        images[current].gameObject.SetActive(false);
        if (currentCombo >= comboLength)
        {
            images[current].fillAmount = 0;
            print("pog");
            //insert repair
            Repaired();

            gameObject.SetActive(false);
        }
        else
        {
            sorryTimer = Time.time + timer;
            images[current].fillAmount = 0;
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
