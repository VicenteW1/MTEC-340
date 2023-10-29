using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameBehavior : MonoBehaviour
{
    // Singleton
    public static GameBehavior Instance;

    public enum GameStates
    {
        Play,
        Pause
    }

    public GameStates State;
    public float PaddleSpeed = 7.0f;

    public float BallSpeedInit = 5.0f;
    public float BallSpeedIncrement = 0.5f;

    public int ScoreToWin = 2;

    public PlayerBehavior[] Players = new PlayerBehavior[2];

    [SerializeField] TextMeshProUGUI _pauseMessage;

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(this);
        else
            Instance = this;

        foreach (PlayerBehavior player in Players)
            player.Score = 0;
                
    }

    public void Start()
    {
        State = GameStates.Play;
        _pauseMessage.enabled = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            State = State == GameStates.Play ? GameStates.Pause
                : GameStates.Play;
            _pauseMessage.enabled = !_pauseMessage.enabled;
        }
    }

    public void UpdateScore(int playerIndex)
    {
        Players[playerIndex - 1].Score++;
        CheckWinner();
    }

    private void CheckWinner()
    {
        foreach (PlayerBehavior player in Players)
        {
            if (player.Score >= ScoreToWin)
            {
                ResetGame();
            }

        }
    }

    private void ResetGame()
    {
        foreach (PlayerBehavior player in Players)
        {
            player.Score = 0; 
        }
    }
}