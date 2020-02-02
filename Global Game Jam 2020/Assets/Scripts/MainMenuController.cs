using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{

    private SpriteRenderer startButton;
    private SpriteRenderer controlsButton;
    private SpriteRenderer quitButton;

    public Sprite startMain;
    public Sprite controlMain;
    public Sprite quitMain;

    public Sprite startAlt;
    public Sprite controlAlt;
    public Sprite quitAlt;

    private int selectedIndex;
    private bool onControls;

    public Camera myCamera;

    // Start is called before the first frame update
    void Start()
    {
        startButton = GameObject.Find("StartButton").GetComponent<SpriteRenderer>();
        controlsButton = GameObject.Find("ControlsButton").GetComponent<SpriteRenderer>();
        quitButton = GameObject.Find("QuitButton").GetComponent<SpriteRenderer>();
        selectedIndex = 0;
        onControls = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Determines which button is "selected" based on the directional input
        //accounts for wrapping
        if(Input.GetKeyDown(KeyCode.JoystickButton5) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            selectedIndex++;
            if(selectedIndex == 3)
            {
                selectedIndex = 0;
            }
        }
        else if(Input.GetKeyDown(KeyCode.JoystickButton4) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            selectedIndex--;
            if(selectedIndex == -1)
            {
                selectedIndex = 2;
            }
        }

        //update the sprites correctly based on which one is "selected"
        if(selectedIndex == 0)
        {
            startButton.sprite = startAlt;
            controlsButton.sprite = controlMain;
            quitButton.sprite = quitMain;
        }
        else if(selectedIndex == 1)
        {
            startButton.sprite = startMain;
            controlsButton.sprite = controlAlt;
            quitButton.sprite = quitMain;
        }
        else
        {
            startButton.sprite = startMain;
            controlsButton.sprite = controlMain;
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
            else if (selectedIndex == 1 && !onControls)
            {
                myCamera.transform.position = new Vector3(myCamera.transform.position.x, myCamera.transform.position.y + 1000, myCamera.transform.position.z);
                onControls = true;
            }
            else
            {
                Application.Quit();
            }
        }
        if((Input.GetKeyDown(KeyCode.JoystickButton1) || Input.GetKeyDown(KeyCode.Escape)) && selectedIndex == 1)
        {
            myCamera.transform.position = new Vector3(myCamera.transform.position.x, myCamera.transform.position.y - 1000, myCamera.transform.position.z);
            onControls = false;
        }
    }
}
