using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createCombo : MonoBehaviour
{

    public GameObject comboPanel;
    public KeyCode startCombo;
    public float _timer;
    public int _comboLength;
    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKeyDown(startCombo)&& comboPanel.activeSelf == false)
        {
            comboPanel.SetActive(true);
            comboPanel.GetComponent<Health>().SetUpGame(_timer, _comboLength);
        }
    }
}
