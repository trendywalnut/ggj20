using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createCombo : MonoBehaviour
{

    public GameObject comboPanel;
    public KeyCode startCombo;
    public float _timer;
    public int _comboLength;

    private Health hp;

    void Start()
    {
        hp = GetComponent<Health>();
    }

    void Update()
    {
        //if(Input.GetKeyDown(startCombo)&& !comboPanel.activeSelf)
        //{
            //comboPanel.SetActive(true);
            //comboPanel.GetComponent<repairCombo>().SetUpGame(_timer, _comboLength);
        //}
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Astronaut" && hp.CurrentHealth < hp.MaxHealth && !comboPanel.activeSelf)
        {
            comboPanel.SetActive(true);
            comboPanel.GetComponent<repairCombo>().SetUpGame(_timer, _comboLength);
        }
    }
}
