using System;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource jumpAudioSource;

    [SerializeField]
    private AudioSource failAudioSource;
    
    [SerializeField]
    private AudioSource backgroundAudioSource;

    private void OnDestroy()
    {
        if (GameManager.Instance != null) {
            GameManager.Instance.OnGameOver -= PlayFailSound;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        if (backgroundAudioSource != null && backgroundAudioSource.clip != null) {
            backgroundAudioSource.loop = true;
            backgroundAudioSource.Play();
        }
        if (GameManager.Instance != null) {
            GameManager.Instance.OnGameOver += PlayFailSound;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) {
            jumpAudioSource.Play();
        }
    }

    private void PlayFailSound()
    {
        failAudioSource.Play();
    }
}
