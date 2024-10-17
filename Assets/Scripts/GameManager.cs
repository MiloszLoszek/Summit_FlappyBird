using System;
using Tripledot.FlappyBird.Leaderboard.UnityDelivery.Views;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public string Nickname => PlayerPrefs.HasKey("nickname") ? PlayerPrefs.GetString("nickname") : string.Empty;

    [SerializeField]
    private GameObject gameView;

    [SerializeField]
    private LobbyView lobbyView;

    [SerializeField]
    private GameObject gameOverCanvas;
    [SerializeField]
    private UnityLeaderboardView leaderboardView;

    public Action OnGameOver;
    public int CurrentScore = 0;

    private void Awake()
    {
        if (Instance == null) {
            Instance = this;
        }

        gameView.SetActive(false);
        Time.timeScale = 1f;
        lobbyView.Show();
    }

    public void GameOver()
    {
        if (!string.IsNullOrEmpty(Nickname)) {
            DependencyManager.Instance.LeaderboardService.Submit(Nickname, CurrentScore);
        }
        OnGameOver?.Invoke();
        gameOverCanvas.SetActive(true);

        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void StartGame(string nickname)
    {
        PlayerPrefs.SetString("nickname", nickname);
        lobbyView.Hide();
        gameView.SetActive(true);
    }

    public void ShowLeaderboard()
    {
        leaderboardView.Init(() => { leaderboardView.Hide(); });
        leaderboardView.Show();
    }

    public void HideLeaderboard()
    {
        leaderboardView.Hide();
    }
}