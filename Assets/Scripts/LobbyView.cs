using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LobbyView : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField nicknameInputField;

    [SerializeField]
    Button playButton;

    [SerializeField]
    private Button leaderboardButton;

    public void Awake()
    {
        playButton.onClick.AddListener(PlayButtonClicked);
        leaderboardButton.onClick.AddListener(LeaderboardButtonClicked);
    }

    public void Start()
    {
        nicknameInputField.text = GameManager.Instance.Nickname;
    }

    private void LeaderboardButtonClicked()
    {
        GameManager.Instance.ShowLeaderboard();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) {
            PlayButtonClicked();
        }

        if (Input.GetKey(KeyCode.R) && Input.GetKey(KeyCode.P) && Input.GetKey(KeyCode.Y)) {
            PlayerPrefs.DeleteAll();
            Debug.Log("All Player Prefs Deleted");
        }
    }

    private void PlayButtonClicked()
    {
        GameManager.Instance.StartGame(nicknameInputField.text);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }
}