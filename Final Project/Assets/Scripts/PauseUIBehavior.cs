using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseUIBehavior : MonoBehaviour
{
    public KeyCode OpenPauseMenu;

    public GameObject pauseMenu;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(OpenPauseMenu))
        {
            TogglePauseMenu();
        }
    }

    void TogglePauseMenu()
    {
        pauseMenu.SetActive(!pauseMenu.activeSelf);

        // If the pause menu is now active, pause the game
        if (pauseMenu.activeSelf)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }
}
