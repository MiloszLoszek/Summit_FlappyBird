using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField]
    private GameObject gameOverCanvas;

    public Action OnGameOver;
    
    private void Awake()
    {
        if (Instance == null) {
            Instance = this;
        }

        Time.timeScale = 1f;
    }

    public void GameOver()
    {
        OnGameOver?.Invoke();
        gameOverCanvas.SetActive(true);

        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
