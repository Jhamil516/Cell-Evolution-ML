using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource sfxAS;
    public AudioSource musicAS;

    public static AudioManager instance;

    [Header("Musica")]
    public AudioClip backgroundMusic;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        if (backgroundMusic != null)
        {
            SetMusic(backgroundMusic, 0.25f);
        }
    }

    public void PlaySFX(
        AudioClip sfx,
        float volume = 1f,
        float pitch = 1f)
    {
        if (sfx == null)
            return;

        sfxAS.pitch = pitch;
        sfxAS.PlayOneShot(sfx, volume);
    }

    public void SetMusic(
        AudioClip music,
        float volume = 1f,
        float pitch = 1f)
    {
        if (music == null)
            return;

        musicAS.pitch = pitch;
        musicAS.volume = volume;
        musicAS.Stop();

        musicAS.clip = music;
        musicAS.loop = true;

        musicAS.Play();
    }
}