using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameBehavior : MonoBehaviour
{
    public static GameBehavior Instance;

    public TMP_Text timerText;
    private float elapsedTime = 0f;
    public bool timerRunning = false;

    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject controlsPanel;
    public GameObject tipsPanel;

    private void Awake()
    {
        {
            if (Instance != null && Instance != this)
                Destroy(Instance.gameObject);
            else
                Instance = this;
        }
    }

    void Update()
    {
        if (timerRunning)
        {
            elapsedTime += Time.deltaTime;
            UpdateTimerUI();
        }

        //if (Input.GetKeyDown(KeyCode.P))
        //{
        //    if (GameIsPaused)
        //    {
        //        Resume();
        //    }
        //    else
        //    {
        //        Pause();
        //    }
        //}
    }


    public void StartTimer()
    {
        if (!timerRunning)
        {
            timerRunning = true;
        }
    }

    public void StopTimer()
    {
        if (timerRunning)
        {
            timerRunning = false;
        }
    }


    void UpdateTimerUI()
    {
        timerText.text = "Time: " + elapsedTime.ToString("F2") + " seconds";
    }

    //void Pause()
    //{
    //    Time.timeScale = 0f;
    //    pauseMenuUI.SetActive(true);
    //    GameIsPaused = true;
    //}

    //public void Resume()
    //{
    //    Time.timeScale = 1f;
    //    pauseMenuUI.SetActive(false);
    //    controlsPanel.SetActive(false);
    //    tipsPanel.SetActive(false);
    //    GameIsPaused = false;
    //}

    //public void ShowControls()
    //{
    //    controlsPanel.SetActive(true);
    //    tipsPanel.SetActive(false);
    //}

    //public void ShowTips()
    //{
    //    controlsPanel.SetActive(false);
    //    tipsPanel.SetActive(true);
    //}

    //public void LoadMenu()
    //{
    //    // Add logic here to load your main menu scene
    //    SceneManager.LoadScene("MainMenu");
    //}

    //public void QuitGame()
    //{
    //    // Add logic here to quit the game
    //    Application.Quit();
    //}
}