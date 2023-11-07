using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Numerics;


public class GameBehavior : MonoBehaviour
{
    public static GameBehavior Instance;

    public enum State
    {
        Play,
        Pause,
    }

    [SerializeField] TextMeshProUGUI _pauseMessage;

    public State CurrentState;

    private void Awake()
    {
        // Singleton pattern
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        CurrentState = State.Play;
        if (CurrentState == State.Play)
        {
            Debug.Log("Play");

            _pauseMessage.enabled = false;
            
        }
    }

    private void Update()
    { 
        if (CurrentState == State.Play)
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                Debug.Log("Pause State");
                CurrentState = CurrentState == State.Play ? State.Pause : State.Play;
                GuiManager.Instance.UpdateMessageGUI(_pauseMessage);
            }
        }
        else if (CurrentState == State.Pause)
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                CurrentState = State.Play;
                GuiManager.Instance.UpdateMessageGUI(_pauseMessage);
            }
        }
    }
}
