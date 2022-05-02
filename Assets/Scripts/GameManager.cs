using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameState State;

    public static event Action<GameState> OnGameStateChanged;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        UpdateGameState(GameState.Pause);
    }

    public void UpdateGameState(GameState newState)
    {
        State = newState;

        switch (newState)
        {
            case GameState.BeginOfChapter:
                break;
        }


        OnGameStateChanged?.Invoke(newState);
    }
   

        public enum GameState
    { 
    Pause,
    BeginOfChapter,
    GotCamera1
    }
}
