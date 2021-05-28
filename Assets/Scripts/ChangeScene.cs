using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
    Basic Class to change between scenes.
*/
public class ChangeScene : MonoBehaviour
{
    public string sceneName; // Scene name to be changed to
    public GameObject button; // button to change scenes
    /**
        Changes to the next scene give by [sceneName]
    */
    public void ChangeScreen()
    {
        SceneManager.LoadScene(sceneName);
    }
    public void Exit()
    {
        Application.Quit();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Joystick1Button0) && button.activeSelf)
        {
            ChangeScreen();
        }
    }
}
