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

    public enum GameState
    {
        waitingToStart,
        Playing,
        Paused,
        EndGame
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

    public void SetGameState(GameState newState)
    {
        CurrentGameState = newState;
        Debug.Log("Game state changed to: " + CurrentGameState);

        switch (newState)
        {
            case GameState.waitingToStart:
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                break;
            case GameState.Playing:
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                break;
            case GameState.EndGame:
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                break;
        }

        OnGameStateChanged?.Invoke(newState);
    }

}
