using UnityEngine;

public class AudioManager : MonoBehaviour
{
     public static AudioManager Instance { get; private set; }

    [Header("Music")]
    [SerializeField] private AudioSource musicSource;
    private float musicVolume = 0.5f;

    [Header("Sfx Settings")]
    private float sfxVolume = 1f;

    void Awake()
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

    private void Start()
    {

        musicVolume = PlayerPrefs.GetFloat("MusicVolume", 0.5f);
        musicSource.volume = musicVolume;

        sfxVolume = PlayerPrefs.GetFloat("SfxVolume", 1f);

    }

    public void PlayMusic(AudioClip clip, float pitch, bool loop = true)
    {
        if (musicSource.clip == clip && musicSource.isPlaying) return;

        musicSource.Stop();
        musicSource.clip = clip;
        musicSource.loop = loop;
        musicSource.pitch = pitch;
        musicSource.Play();
    }

    public void ChangeMusicVolume(float volume)
    {
        musicSource.volume = volume;
        PlayerPrefs.SetFloat("MusicVolume", volume);
        PlayerPrefs.Save();
    }

    public void ChangeSfxVolume(float volume)
    {
        sfxVolume = volume;
        PlayerPrefs.SetFloat("SfxVolume", volume);
        PlayerPrefs.Save();
    }

    public void PlaySfx(AudioClip clip, AudioSource sfxSource, float pitch = 1f)
    {
        if (sfxSource.clip == clip && sfxSource.isPlaying) return;

        sfxSource.pitch = pitch;
        sfxSource.PlayOneShot(clip, sfxVolume);
    }
}
