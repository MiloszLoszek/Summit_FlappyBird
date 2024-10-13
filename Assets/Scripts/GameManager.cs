using System;
using Tripledot.FlappyBird.Leaderboard.UnityDelivery.Views;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField]
    private GameObject gameOverCanvas;
    [SerializeField]
    private UnityLeaderboardView leaderboardView;

    public Action OnGameOver;

    private void Awake()
    {
        if (Instance == null) {
            Instance = this;
        }

        Time.timeScale = 1f;
    }

    private void Start()
    {
        leaderboardView.Init(() => {
            /* TODO: Show main menu or something */
        });
        // TODO: Delete Example Usage
        DependencyManager.Instance.LeaderboardService.Submit("Test1", 20);
        DependencyManager.Instance.LeaderboardService.Submit("Test2", 30);
        DependencyManager.Instance.LeaderboardService.Submit("Test3", 50);
        DependencyManager.Instance.LeaderboardService.Submit("Test4", 40);
        leaderboardView.Show();
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