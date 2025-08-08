using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance
    {
        get { return _instance; }
    }
    public GameState CurrentGameState { get; private set; }
    public static event Action<GameState> OnGameStateChanged;
    public bool canSpawn;

    public enum GameState
    {
        MainMenu,
        waitingToStart,
        Playing,
        Paused,
        EndGame,
        WinGame
    }

    private void Awake()
    {
        if (Instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        SetGameState(GameState.MainMenu);
    }

    public void SetGameState(GameState newState)
    {
        CurrentGameState = newState;
        Debug.Log("Game state changed to: " + CurrentGameState);

        switch (newState)
        {
            case GameState.MainMenu:
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                break;
            case GameState.waitingToStart:
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                break;
            case GameState.Playing:
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                break;
            case GameState.EndGame:
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                break;
            case GameState.WinGame:
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                break;
        }

        OnGameStateChanged?.Invoke(newState);
    }

}
