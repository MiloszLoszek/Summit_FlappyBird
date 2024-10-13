using Tripledot.FlappyBird.Leaderboard.Domain.Services;
using Tripledot.FlappyBird.Leaderboard.Infrastructure.Services;
using UnityEngine;

public class DependencyManager : MonoBehaviour
{
    public static DependencyManager Instance;

    private LeaderboardService leaderboardService;
    public LeaderboardService LeaderboardService =>
        leaderboardService ??= new DiskLeaderboardService(new PlayerPrefsStorageService());
    
    private void Awake()
    {
        if (Instance == null) {
            Instance = this;
        }
    }
}