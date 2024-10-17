using System;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public static Score Instance;
    private const string HighScorePrefsKey = "hs";

    [SerializeField]
    private TextMeshProUGUI currentScoreText;
    [SerializeField]
    private TextMeshProUGUI highScoreText;

    private int score;

    private void Awake()
    {
        if (Instance == null) {
            Instance = this;
        }
    }

    private void Start()
    {
        currentScoreText.text = score.ToString();

        highScoreText.text = PlayerPrefs.GetInt(HighScorePrefsKey, 0).ToString();
        UpdateHighscore();
    }
    
    public void UpdateScore()
    {
        score++;
        currentScoreText.text = score.ToString();
        GameManager.Instance.CurrentScore = score;
        UpdateHighscore();
    }

    private void UpdateHighscore()
    {
        if (score <= PlayerPrefs.GetInt(HighScorePrefsKey)) {
            return;
        }
        
        PlayerPrefs.SetInt(HighScorePrefsKey, score);
        highScoreText.text = score.ToString();
    }
}
