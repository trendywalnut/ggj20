using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
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

        if (Input.GetKeyDown(KeyCode.Z))
        {

            Broken();
            
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            Repaired();
        }
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
}
