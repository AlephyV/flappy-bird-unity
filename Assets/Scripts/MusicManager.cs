using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip gameOver;
    public AudioClip theme;

    public AudioSource effectsSource;
    public AudioClip upDifficulty;
    void Start()
    {
        audioSource.clip = theme;
        audioSource.loop = true;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playCollision()
    {
        audioSource.Stop();
        audioSource.clip = gameOver;
        audioSource.loop = false;
        audioSource.Play();
    }

    public void playUpDifficulty()
    {
        effectsSource.clip = upDifficulty;
        effectsSource.loop = false;
        effectsSource.Play();
    }
}
