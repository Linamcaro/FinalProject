using UnityEngine;

public class MusicController : MonoBehaviour
{
    public static MusicController Instance { get; private set; }

    public AudioClip PlayMenu;
    public AudioClip PlayGamePlay;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameManager.OnGameStateChanged += MusicController_OnGameStateChanged;

        MusicController_OnGameStateChanged(GameManager.Instance.CurrentGameState);
    }

    private void MusicController_OnGameStateChanged(GameManager.GameState state)
    {
        if (state == GameManager.GameState.MainMenu || state == GameManager.GameState.waitingToStart)
        {
            SetMusic(PlayMenu);
        }
        else if (state == GameManager.GameState.Playing)
        {
            SetMusic(PlayGamePlay, 1.3f);
        }

    }


    private void SetMusic(AudioClip musicClip, float pitch = 1f, bool loop = true)
    {
        if (AudioManager.Instance != null)
            AudioManager.Instance.PlayMusic(musicClip, pitch, loop);

    }

    private void OnDestroy()
    {
        GameManager.OnGameStateChanged -= MusicController_OnGameStateChanged;
    }

}
