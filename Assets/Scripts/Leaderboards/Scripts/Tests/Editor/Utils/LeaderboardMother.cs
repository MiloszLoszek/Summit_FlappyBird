using System;
using Tripledot.FlappyBird.Leaderboard.Domain.Model;

namespace Tripledot.FlappyBird.Leaderboard.Scripts.Tests.Editor.Utils
{
    public static class LeaderboardMother
    {
        public static Domain.Model.Leaderboard ALeaderboard(DateTime withStartDate = default,
            DateTime withEndDate = default, LeaderboardPlayerData[] withPlayersInfo = null)
        {
            return new Domain.Model.Leaderboard(withStartDate,
                withEndDate,
                withPlayersInfo ?? new LeaderboardPlayerData[]{});
        }
    }
}