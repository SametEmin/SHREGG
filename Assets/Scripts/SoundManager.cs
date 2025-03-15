using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public AudioSource audioSource;
    public Slider volumeSlider;
    public AudioClip mainMenuMusic;
    public AudioClip mainTrack;
    public AudioClip dramaticBoss;
    public AudioClip finalBoss;
    public AudioClip endingMusic; // New Ending Music

    private Coroutine fadeCoroutine;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    void Start()
    {
        audioSource.loop = true;
        audioSource.volume = volumeSlider.value;
        volumeSlider.onValueChanged.AddListener(SetVolume);

        // Play correct music based on the initial scene
        HandleSceneMusic(SceneManager.GetActiveScene().name);

        // Listen for scene changes
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        HandleSceneMusic(scene.name);
    }

    private void HandleSceneMusic(string sceneName)
    {
        if (sceneName == "MainMenu")
        {
            PlayMusic(mainMenuMusic);
        }
        else if (sceneName == "War_Area") // Adjust name to your main gameplay scene
        {
            PlayMusic(mainTrack);
        }
        else if (sceneName == "EndingScene") // Adjust name to your ending scene
        {
            PlayMusic(endingMusic);
        }
    }

    public void PlayMusic(AudioClip newTrack)
    {
        if (audioSource.clip == newTrack) return;

        if (fadeCoroutine != null) StopCoroutine(fadeCoroutine);
        fadeCoroutine = StartCoroutine(FadeToNewTrack(newTrack));
    }

    private IEnumerator FadeToNewTrack(AudioClip newTrack)
    {
        float fadeDuration = 1.5f;
        float startVolume = audioSource.volume;

        // Fade out
        for (float t = 0; t < fadeDuration; t += Time.deltaTime)
        {
            audioSource.volume = Mathf.Lerp(startVolume, 0, t / fadeDuration);
            yield return null;
        }

        // Switch tracks
        audioSource.clip = newTrack;
        audioSource.Play();

        // Fade in
        for (float t = 0; t < fadeDuration; t += Time.deltaTime)
        {
            audioSource.volume = Mathf.Lerp(0, volumeSlider.value, t / fadeDuration);
            yield return null;
        }
    }

    public void PlayDramaticBoss() { PlayMusic(dramaticBoss); }
    public void PlayMainTrack() { PlayMusic(mainTrack); }
    public void PlayFinalBoss() { PlayMusic(finalBoss); }
    public void PlayEndingMusic() { PlayMusic(endingMusic); }
    public void SetVolume(float volume) { audioSource.volume = volume; }

    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void Update()
{
    if (Input.GetKeyDown(KeyCode.Alpha1)) PlayMainTrack();       // Press "1" for Main Track
    if (Input.GetKeyDown(KeyCode.Alpha2)) PlayDramaticBoss();    // Press "2" for Dramatic Boss
    if (Input.GetKeyDown(KeyCode.Alpha3)) PlayFinalBoss();       // Press "3" for Final Boss
    if (Input.GetKeyDown(KeyCode.Alpha4)) PlayEndingMusic();     // Press "4" for Ending Music
}
}
