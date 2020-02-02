using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
   
    public float CurrentHealth { get; set; }
    public float MaxHealth { get; set; }

    public float healthAmount = 1000f;

    private bool isBroken;

    private bool isAstro;

    public Slider healthBar;
    void Start()
    {
        MaxHealth = healthAmount;
        CurrentHealth = MaxHealth;
        isBroken = false;

        healthBar.value = CalaculateHealth();
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.value = CalaculateHealth();
        DealDamage();

        //if (Input.GetKeyDown(KeyCode.Z))
        //{

        //    Broken();
            
        //}
        //if (Input.GetKeyDown(KeyCode.X))
        //{
        //    Repaired();
        //}

        
        

    }

    public void Repaired()
    {

        if (isAstro == true)
        {
            isBroken = false;
            CurrentHealth = MaxHealth;
        }
       
    }
    void Broken()
    {
        isBroken = true;
        //ship hit
        GetComponent<AudioSource>().Play();
    }
    void DealDamage ()
    {
        if (isBroken)
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
        SceneManager.LoadScene("Game Over Screen");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag != "Astronaut" && collision.gameObject.tag != "Satellite")
        {
            Broken();
        }

        if (collision.gameObject.tag == "Astronaut")
        {
            isAstro = true;
        }

        if (collision.gameObject.tag == "Satellite")
        {
            isAstro = false;
        }
    }

    
    
    
}
