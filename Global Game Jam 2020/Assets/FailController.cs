using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FailController : MonoBehaviour
{

    private SpriteRenderer retryButton;
    private SpriteRenderer quitButton;

    public Sprite retryMain;
    public Sprite quitMain;

    public Sprite retryAlt;
    public Sprite quitAlt;

    private int selectedIndex;

    // Start is called before the first frame update
    void Start()
    {
        retryButton = GameObject.Find("RetryButton").GetComponent<SpriteRenderer>();
        quitButton = GameObject.Find("QuitButton").GetComponent<SpriteRenderer>();
        selectedIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Determines which button is "selected" based on the directional input
        //accounts for wrapping
        if (Input.GetKeyDown(KeyCode.JoystickButton5) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            selectedIndex++;
            if (selectedIndex == 2)
            {
                selectedIndex = 0;
            }
        }
        else if (Input.GetKeyDown(KeyCode.JoystickButton4) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            selectedIndex--;
            if (selectedIndex == -1)
            {
                selectedIndex = 1;
            }
        }

        //update the sprites correctly based on which one is "selected"
        if (selectedIndex == 0)
        {
            retryButton.sprite = retryAlt;
            quitButton.sprite = quitMain;
        }
        else
        {
            retryButton.sprite = retryMain;
            quitButton.sprite = quitAlt;
        }
        Debug.Log(selectedIndex);
        if (Input.GetKeyDown(KeyCode.JoystickButton0) || Input.GetKeyDown(KeyCode.Return))
        {
            if (selectedIndex == 0)
            {
                //replace with first level scene
                SceneManager.LoadScene("Level 1");
            }
            else
            {
                Application.Quit();
            }
        }
    }
}
